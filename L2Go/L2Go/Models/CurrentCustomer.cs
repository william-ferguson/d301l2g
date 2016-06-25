using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;

namespace L2Go.Models
{
    class CurrentCustomer
    {
        [PrimaryKey]
        public int ID { get; set; }
    }
}
