using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Models
{
    public class ImportedObjectsBuilder
    {
        public ImportedObjects ImportedObjects = new ImportedObjects();
        public string FilePath { get; set; }

        #region
        public ImportedObjectsBuilder(string filePath)
        {
            this.FilePath = filePath;
        }
        public ImportedObjects Build()
        {
            var splitedData = DataProcessor.DevideStringList(CsvReader.ReadFile(this.FilePath));
            AddDatabases(splitedData);
            AddTables(splitedData);
            AddColumns(splitedData);
            return GetImportedObjects();
        }
        #endregion Public methods

        #region
        private ImportedObjects GetImportedObjects()
        {
            return this.ImportedObjects;
        }
        
        private void AddDatabases(List<string[]> splitedData)
        {
            foreach (var values in splitedData)
            {
                if (values[Constants.Type].Equals(Constants.Database, StringComparison.CurrentCultureIgnoreCase))
                {
                    var database = new Database();
                    ImportedObjects.databases.Add(values[Constants.Name], database);
                }
            }
        }
        private void AddTables(List<string[]> splitedData)
        {
            foreach (var values in splitedData)
            {
                if (values[Constants.Type].Equals(Constants.Table, StringComparison.CurrentCultureIgnoreCase))
                {
                    var table = new Table(values[Constants.Schema]);
                    if (ImportedObjects.databases.TryGetValue(values[Constants.ParentName], out var foundDataBase))
                    {
                        foundDataBase.tables.Add(values[Constants.Name], table);
                    }
                    else
                    {
                        ImportedObjects.databases[Constants.NotFound].tables.Add(values[Constants.Name], table);
                    }
                }
            }
        }
        private void AddTableWithoutDatabase(string tableName, string schema)
        {
            var table = new Table(schema);
            ImportedObjects.databases[Constants.NotFound].tables.Add(tableName, table);
        }

        private void AddColumns(List<string[]> splitedData)
        {
            foreach (var values in splitedData)
            {
                var column = new Column(values[Constants.Name], values[Constants.DataType], values.Count() < 7 ? Constants.NotPassed : values[Constants.IsNullable]);
                if (values[Constants.Type].Equals(Constants.Column, StringComparison.CurrentCultureIgnoreCase))
                {
                    var columnTable = ImportedObjects.GetTableFromDatabases(values[Constants.ParentName]);
                    //No database in input file- creating table from clolumn ParentName and schema, submitting into NOT_FOUND database
                    if (columnTable == null)
                    {
                        AddTableWithoutDatabase(values[Constants.ParentName], values[Constants.Schema]);
                        columnTable = ImportedObjects.GetTableFromDatabases(values[Constants.ParentName]);
                        columnTable.columns.Add(column);
                    }
                    else
                    {
                        columnTable.columns.Add(column);
                    }
                }
            }
        }
        #endregion Private methods
    }
}
