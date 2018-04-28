using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domasno_2.Models
{
    public class Title
    {
        public int ID { get; set; }

        public string TitleName { get; set; }

        public DateTime PublicationYear { get; set; }

        public ICollection<Publisher> Publishers { get; set; }

    }
}
