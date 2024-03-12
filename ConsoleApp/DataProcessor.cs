using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public static class DataProcessor
    {
        public static List<string[]> DevideStringList(List<string> inputList)
        {
            var resultList = inputList.Select(inputString => inputString.Split(';')).ToList();
            return resultList;
        }
    }
}
