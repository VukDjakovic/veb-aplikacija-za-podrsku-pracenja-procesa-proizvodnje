using KlasePodataka;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using KlasePodataka;
using KlaseMapiranja;

namespace SlojPoslovneLogike
{
    public class PoslovnaPravila
    {
        private Maper maper;

        public PoslovnaPravila()
        {
            maper = new Maper();
        }
        public bool ValidirajDatumPlana(DateTime datumPlana)
        {
            return datumPlana >= DateTime.Today;
        }
        public bool ValidirajStatusPlana(string StatusPlana)
        {
            var statusi = maper.DajSveStatusePlana();
            return statusi.Contains(StatusPlana);
        }

        public bool ValidirajDatumRealizacije(DateTime datumRealizacije)
        {
            return datumRealizacije >= DateTime.Today;
        }

        public bool ValidirajKolicinu(string nazivSektora, int kolicina)
        {
            if (kolicina <= 0)
                return false;

            var ogranicenja = maper.DajOgranicenjaPoSektorima();
            var maxKolicina = ogranicenja
                .FirstOrDefault(x => x.NazivSektora.Equals(nazivSektora, StringComparison.OrdinalIgnoreCase))
                ?.MaksimalnaDnevnaKolicina ?? 0;

            return kolicina <= maxKolicina;
        }


        public List<string> DajSveStatusePlana()
        {
            return maper.DajSveStatusePlana();
        }
    }
}
