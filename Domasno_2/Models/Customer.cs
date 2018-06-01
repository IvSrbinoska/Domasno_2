using Microsoft.EntityFrameworkCore;
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

        [Range(10, 40)]
        public int  Age { get; set; }
        public Boolean Active { get; set; }
        public ICollection<Address> Addresses { get; set; }
        public ICollection<Title> Titles { get; set; }
        public ICollection<Publisher> Publishers { get; set; }

    }

}
