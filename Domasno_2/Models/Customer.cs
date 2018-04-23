using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Domasno_2.Models
{
    public class Customer
    {
        public int ID { get; set; }

        public string FullName { get; set; }

        public string Gender { get; set; }

        [Range(18, 88)]
        public int  Age { get; set; }

        public Boolean Active { get; set; }
    }
}
