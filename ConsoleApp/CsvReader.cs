﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public static class CsvReader
    {
        public static List<string> ReadFile(string filePath)
        {
            var streamReader = new StreamReader(filePath);
            var importedLines = new List<string>();
            while (!streamReader.EndOfStream)
            {
                var line = streamReader.ReadLine();
                if (!string.IsNullOrEmpty(line))
                {
                    importedLines.Add(line);
                }
            }
            return importedLines;
        }
    }
}
