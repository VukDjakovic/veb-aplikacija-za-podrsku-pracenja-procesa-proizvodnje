using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlasePodataka
{
    public class Porudzbina
    {
        public int PorudzbinaID { get; set; }
        public string DatumPorudzbine { get; set; }
        public Kupac Kupac { get; set; }
    }
}
