using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebScanner.Classes {
    public class Domain {
        public int DomainId { get; set; }
        public string Uri { get; set; }
        public string Html { get; set; }

        public Domain() {
            this.Links = new List<Link>();
        }

        public virtual List<Link> Links { get; set; }
    }
}
