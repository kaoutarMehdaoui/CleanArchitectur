

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cleanArchitectureBiblo.ModelDTO
{
    public class LivreDTO : ComanDTO
    {

        public int nbrpage { get; set; }
        public string type { get; set; }
        public string tome { get; set; }
        public int AdherentId { get; set; }


    }
}
