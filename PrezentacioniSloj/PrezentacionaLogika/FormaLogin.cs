using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KlasePodataka;

namespace PrezentacionaLogika
{
    public class FormaLogin
    {
        private KorisnikDB korisnikDB;

        public FormaLogin()
        {
            korisnikDB = new KorisnikDB();
        }

        public DataSet ValidacijaKorisnika(string KorisnickoIme, string Lozinka)
        {
            return korisnikDB.ValidacijaKorisnika(KorisnickoIme, Lozinka);
        }
    }
}
