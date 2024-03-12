using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Models
{
    public class Database
    {
        public Dictionary<string, Table> tables;
        public Database()
        {
            this.tables = new Dictionary<string, Table>();
        }
    }
}
