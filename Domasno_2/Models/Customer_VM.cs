using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domasno_2.Models
{
    public class Customer_VM
    {
        public int ID { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public Boolean Active { get; set; }
    }
}
