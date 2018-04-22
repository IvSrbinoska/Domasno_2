using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Domasno_2.Models
{
    public class Address
    {
        public int ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Display(Name = "adresa linija 1")]
        public string Address1 { get; set; }

        [Display(Name = "adresa 2")]
        public string Address2 { get; set; }

        public string City { get; set; }

        [Display(Name = "Zip")]
        public int PostalCode { get; set; }
    }
}
