namespace ConsoleApp
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class Program
    {
        static void Main(string[] args)
        {
            ImportedObjectsBuilder importedObjectBuilder = new ImportedObjectsBuilder("data.csv");
            var importedObjects = importedObjectBuilder.Build();
            DataPrinter.printImportedObjects(importedObjects);
            Console.ReadLine();
        }
    }
}
