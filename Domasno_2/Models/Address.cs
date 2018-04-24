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

        [StringLength(maximumLength: 35)]
        public string FirstName { get; set; }

        [StringLength(maximumLength: 15)]
        public string LastName { get; set; }

        public string Address1 { get; set; }

        [Display(Name = "adresa 2")]
        public string Address2 { get; set; }

        public string City { get; set; }

        [Display(Name = "Zip")]
        [StringLength(10, MinimumLength =5)]
        public string PostalCode { get; set; }

        public Customer Customer { get; set; }
    }
}
