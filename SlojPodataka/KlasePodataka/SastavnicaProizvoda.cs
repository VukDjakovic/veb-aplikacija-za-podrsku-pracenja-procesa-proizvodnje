using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlasePodataka
{
    public class SastavnicaProizvoda
    {
        public int SastavnicaProizvodaID { get; set; }

        public DeoProizvoda DeoProizvoda { get; set; }

        public Proizvod Proizvod { get; set; }

        public int KolicinaDelova { get; set; }
    }
}
