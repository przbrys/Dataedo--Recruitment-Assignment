using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Models
{
    public class ImportedObjects
    {
        public Dictionary<string, Database> databases;
        public ImportedObjects()
        {
            databases = new Dictionary<string, Database>();
            Database notFoundDb = new Database();
            this.databases.Add(Constants.NotFound, notFoundDb);
        }
        public Table GetTableFromDatabases(string tableName)
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
}
