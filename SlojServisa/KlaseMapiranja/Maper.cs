using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KlaseMapiranja.WebService;
using KlasePodataka;

namespace KlaseMapiranja
{
    public class Maper
    {
        private WebService1 ws;

        public Maper()
        {
            ws = new WebService1();
        }

        public List<string> DajSveStatusePlana()
        {
            return ws.DajSveStatusePlana().ToList();
        }

        public List<KlasePodataka.SektorOgranicenjeDTO> DajOgranicenjaPoSektorima()
        {
            var servisLista = ws.DajOgranicenjaPoSektorima();

            var lokalnaLista = servisLista.Select(s => new KlasePodataka.SektorOgranicenjeDTO
            {
                NazivSektora = s.NazivSektora,
                MaksimalnaDnevnaKolicina = s.MaksimalnaDnevnaKolicina
            }).ToList();

            return lokalnaLista;
        }
    }
}
