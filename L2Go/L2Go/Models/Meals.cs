using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;

namespace L2Go.Models
{
    //class that holds the meal values
    public class Meals
    {

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Meal { get; set; }
        public string Flavour { get; set; }
        public string Time { get; set; }
        public string Price { get; set; }
        public int CustID { get; set; }

    }


}
