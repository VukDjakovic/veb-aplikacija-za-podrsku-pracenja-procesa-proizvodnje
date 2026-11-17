using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlasePodataka
{
    public class DetaljniPlanProizvodnje
    {
        public int DetaljniPlanID { get; set; }
        public PlanProizvodnje PlanProizvodnje { get; set; }
        public StavkePorudzbine StavkePorudzbine { get; set; }
        public SastavnicaProizvoda SastavnicaProizvoda { get; set; }
        public int Kolicina { get; set; }
    }
}
