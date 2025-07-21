using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlTable = SQLite.TableAttribute;
using SqlColumn = SQLite.ColumnAttribute;
using SQLiteDemo.Abstractions;


namespace SQLiteDemo.MVVM.Models
{
    [SqlTable("Customers")]
    public class Customer : TableData
    {

        [SqlColumn("name"), Indexed, NotNull]

        public string Name { get; set; }
        [Unique]
        public string Phone { get; set; }

        public int Age { get; set; }
        [MaxLength(100)]
        public string Address { get; set; }
        [Ignore]

        public bool IsYoung =>
            Age > 50 ? true : false;
    }
}
