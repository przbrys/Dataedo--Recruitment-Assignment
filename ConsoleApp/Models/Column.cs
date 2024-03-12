using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Models
{
    public class Column
    {
        public string Name { get; set; }
        public string DataType { get; set; }
        public string IsNullabe { get; set; }
        public Column(string name, string dataType, string isNullable)
        {
            this.Name = name;
            this.DataType = dataType;
            this.IsNullabe = isNullable;
        }
    }
}
