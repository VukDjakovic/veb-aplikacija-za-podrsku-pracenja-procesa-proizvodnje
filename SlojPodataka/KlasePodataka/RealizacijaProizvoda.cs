using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlasePodataka
{
    public class RealizacijaProizvoda
    {
        public int RealizacijaProizvodaID { get; set; }
        public Proizvod Proizvod { get; set; }
        public int RealizovanaKolicina { get; set; }
        public string DatumRealizacije { get; set; }
        public Sektor Sektor { get; set; }
    }
}
