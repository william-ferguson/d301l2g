using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;


namespace L2Go.Models
{
    class order
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public string OrderTime { get; set; }
        public string OrderDate { get; set; }
        public string OrderRegion { get; set; }


    }
}
