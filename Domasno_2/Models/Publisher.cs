using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domasno_2.Models
{
    public class Publisher
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string StreetAdr { get; set; }

        public string ZipCode { get; set; }

        public Title Title { get; set; }


    }
}
