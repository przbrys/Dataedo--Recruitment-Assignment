using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Models
{
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
}
