using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using KlasePodataka;

namespace PrezentacionaLogika
{
    public class FormaPorudzbinaPregled
    {
        private PorudzbinaDB porudzbinaDB;

        public FormaPorudzbinaPregled()
        {
            porudzbinaDB = new PorudzbinaDB();
        }

        public DataSet PorudzbinaPrikaz(int porudzbinaID)
        {
            return porudzbinaDB.PorudzbinaPrikaz(porudzbinaID);
        }
    }
}
