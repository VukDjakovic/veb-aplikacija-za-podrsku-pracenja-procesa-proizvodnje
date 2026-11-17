using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlasePodataka
{
    public class PlanProizvodnje
    {
        public int PlanID { get; set; }
        public string DatumRokaIzrade { get; set; }
        public Porudzbina Porudzbina { get; set; }
        public string StatusPlana { get; set; }
    }
}
