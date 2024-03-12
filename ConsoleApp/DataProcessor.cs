using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class DataProcessor
    {
        public static List<string[]> DevideStringList(List<string> inputList)
        {
            var resultList = new List<string[]>();
            foreach (string inputString in inputList)
            {
                string[] values = inputString.Split(';');
                resultList.Add(values);
            }
            return resultList;
        }
    }
}
