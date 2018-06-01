using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Domasno_2.Models
{
    public class Address_ViewModel
    {
        [Required]
        public int ID { get; set; }
        [StringLength(maximumLength: 35)]
        public string FirstName { get; set; }
        [StringLength(maximumLength: 15)]
        public string LastName { get; set; }

        [Required]
        public string City { get; set; }
    }
}
