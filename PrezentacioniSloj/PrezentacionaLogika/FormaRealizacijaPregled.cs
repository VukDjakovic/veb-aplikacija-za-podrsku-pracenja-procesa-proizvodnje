using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using KlasePodataka;

namespace PrezentacionaLogika
{
    public class FormaRealizacijaPregled
    {
        private RealizacijaDB realizacijaDB;

        public FormaRealizacijaPregled()
        {
            realizacijaDB = new RealizacijaDB();
        }

        public DataSet RealizacijaDelovaPrikaz(int realizacijaID)
        {
            return realizacijaDB.RealizacijaDelovaPrikaz(realizacijaID);
        }

        public DataSet RealizacijaProizvodaPrikaz(int realizacijaID)
        {
            return realizacijaDB.RealizacijaProizvodaPrikaz(realizacijaID);
        }
    }
}
