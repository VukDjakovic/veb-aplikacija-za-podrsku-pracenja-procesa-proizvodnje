using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlasePodataka
{
    public class RealizacijaDelova
    {
        public int RealizacijaDelovaID { get; set; }
        public DeoProizvoda DeoProizvoda { get; set; }
        public int RealizovanaKolicina { get; set; }
        public string DatumRealizacije { get; set; }
        public Sektor Sektor { get; set; }
    }
}
