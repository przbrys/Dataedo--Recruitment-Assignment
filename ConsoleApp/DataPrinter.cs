using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Models
{
    public static class DataPrinter
    {
        public static void PrintImportedObjects(ImportedObjects importedObjects) 
        {
            foreach (var database in importedObjects.databases)
            {
                Console.WriteLine($"Database: {database.Key} ({database.Value.tables.Count} tables)");
                Console.WriteLine();

                foreach (var table in database.Value.tables)
                {
                    Console.WriteLine($"\tTable: {table.Key} ({table.Value.columns.Count} columns)");

                    foreach (var column in table.Value.columns)
                    {
                        Console.WriteLine($"\t\tColumn: {column.Name} - DataType: {column.DataType}, IsNullable: {column.IsNullabe}");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("---------------------------------------------------------------------------");
            }
        }
    }
}
