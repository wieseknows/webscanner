using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebScanner.Classes {
    public class Link {
        public int LinkId { get; set; }
        public string Href { get; set; }

        public Domain Domain { get; set; }
    }
}
