using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Adherent:Comman
    {
        public String cin { get; set; }
        public String metier { get; set; }
        public List<Livre> livres { get; set; }
    }
}
