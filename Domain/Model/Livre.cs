using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Livre : Comman
    {
        public int nbrpage { get; set; }
        public string type { get; set; }
        public string tome { get; set; }
    }
}
