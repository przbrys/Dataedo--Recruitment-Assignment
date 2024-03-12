using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class ImportedObjects
    {
        public Dictionary<string, Database> databases {  get; set; }
        public ImportedObjects()
        {
            databases = new Dictionary<string, Database>();

            Database notFoundDb = new Database();
            this.databases.Add("NOT_FOUND", notFoundDb);
        }
        public Table getTableFromDatabases(string tableName)
        {
            foreach(var database in databases)
            {
                if (database.Value.tables.ContainsKey(tableName))
                {
                    return database.Value.tables[tableName];
                }
            }
            return null;
        }
    }

    public class Database
    {
        public Dictionary<string, Table> tables;
        public Database()
        {
            this.tables = new Dictionary<string, Table>();
        }
    }

    public class Table
    {
        public List<Column> columns;
        public string Schema { get; set; }

        public Table(string schema)
        {
            this.columns = new List<Column>();
            this.Schema = schema;
        }
    }

    public class Column
    {
        public string Name { get; set; }
        public string DataType { get; set; }
        public string IsNullabe {  get; set; }
        public Column(string name, string dataType, string isNullable)
        {
            this.Name = name;
            this.DataType = dataType;
            this.IsNullabe = isNullable;
        }
    }


    public class ImportedObjectsBuilder
    {
        public ImportedObjects ImportedObjects = new ImportedObjects();
        public string FilePath {  get; set; }

        private ImportedObjects GetImportedObjects()
        {
            return this.ImportedObjects;
        }

        public ImportedObjectsBuilder(string filePath)
        {
            this.FilePath = filePath;
        }

        private void AddDatabases(List<string[]> splitedData) 
        {
            foreach(var values in splitedData)
            {
                if (values[0].ToLower() == "database")
                {
                    var database = new Database();
                    ImportedObjects.databases.Add(values[1], database);
                }
            }
        }
        private void AddTables(List<string[]> splitedData)
        {
            foreach (var values in splitedData)
            {
                if (values[0].ToLower()=="table")
                {
                    var table = new Table(values[2]);
                    if(ImportedObjects.databases.TryGetValue(values[3], out var foundDataBase))
                    {
                        foundDataBase.tables.Add(values[1], table);
                    }
                    else
                    {
                        ImportedObjects.databases["NOT_FOUND"].tables.Add(values[1], table);
                    }    
                }
            }
        }
        private void AddTableWithoutDatabase(string tableName, string schema)
        {
            var table = new Table(schema);
            ImportedObjects.databases["NOT_FOUND"].tables.Add(tableName, table);
        }

        private void AddColumns(List<string[]> splitedData)
        {
            foreach(var values in splitedData)
            {
                var column = new Column(values[1], values[5], values.Count() < 7 ? "NOT_PASSED" : values[6]);
                if (values[0].ToLower()=="column")
                {                   
                    var columnTable = ImportedObjects.getTableFromDatabases(values[3]);
                    //No database in input file- creating table from clolumn ParentName and schema, submitting into NOT_FOUND database
                    if(columnTable==null)
                    {
                        AddTableWithoutDatabase(values[3], values[2]);
                        columnTable = ImportedObjects.getTableFromDatabases(values[3]);
                        columnTable.columns.Add(column);
                    }
                    else
                    {
                        columnTable.columns.Add(column);
                    }
                }              
            }
        }

        public ImportedObjects Build()
        {
            var splitedData = DataProcessor.DevideStringList(CsvReader.ReadFile(this.FilePath));
            AddDatabases(splitedData);
            AddTables(splitedData);
            AddColumns(splitedData);  
            return GetImportedObjects();
        }
    }
}
