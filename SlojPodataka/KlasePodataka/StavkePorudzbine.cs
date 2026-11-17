using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlasePodataka
{
    public class StavkePorudzbine
    {
        public int StavkePorudzbineID { get; set; }
        public Porudzbina Porudzbina { get; set; }
        public Proizvod Proizvod { get; set; }
        public int Kolicina { get; set; }
        public decimal CenaPoJedinici { get; set; }
        public decimal UkupnaCena { get; set; }
    }
}
