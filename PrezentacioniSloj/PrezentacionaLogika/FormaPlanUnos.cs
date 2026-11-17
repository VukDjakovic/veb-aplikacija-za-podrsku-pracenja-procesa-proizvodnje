using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using KlasePodataka;
using SlojPoslovneLogike;

namespace PrezentacionaLogika
{
    public class FormaPlanUnos
    {
        private PoslovnaPravila pravila;
        private PlanDB planDB;

        public FormaPlanUnos()
        {
            pravila = new PoslovnaPravila();
            planDB = new PlanDB();
        }

        public bool PlanUnos(string datumRokaIzradeText, string porudzbinaIDText, string statusPlana)
        {
            if (string.IsNullOrWhiteSpace(datumRokaIzradeText))
                throw new Exception("Datum realizacije mora biti unet!");
            if (!DateTime.TryParse(datumRokaIzradeText, out DateTime datumRokaIzrade))
                throw new Exception("Datum nije u ispravnom formatu!");

            if (string.IsNullOrWhiteSpace(porudzbinaIDText))
                throw new Exception("ID porudžbine mora biti unet!");
            if (!int.TryParse(porudzbinaIDText, out int porudzbinaID))
                throw new Exception("ID porudžbine mora biti broj!");

            if (string.IsNullOrWhiteSpace(statusPlana))
                throw new Exception("Status plana mora biti unet!");
            if (statusPlana.Length > 50)
                throw new Exception("Status ne može imati više od 50 karaktera!");

            if (!pravila.ValidirajDatumPlana(datumRokaIzrade))
                throw new Exception("Datum roka izrade ne može biti pre današnjeg datuma!");
            if (!pravila.ValidirajStatusPlana(statusPlana))
                throw new Exception("Status plana nije validan!");

            return planDB.PlanAutomatskiUnos(datumRokaIzrade, porudzbinaID, statusPlana);
        }

        public bool PlanIzmena(int planID, string datumRokaIzradeText, string statusPlana)
        {
            if (string.IsNullOrWhiteSpace(datumRokaIzradeText))
                throw new Exception("Datum realizacije mora biti unet!");
            if (!DateTime.TryParse(datumRokaIzradeText, out DateTime datumRokaIzrade))
                throw new Exception("Datum nije u ispravnom formatu!");

            if (string.IsNullOrWhiteSpace(statusPlana))
                throw new Exception("Status plana mora biti unet!");
            if (statusPlana.Length > 50)
                throw new Exception("Status ne može imati više od 50 karaktera!");

            if (!pravila.ValidirajDatumPlana(datumRokaIzrade))
                throw new Exception("Datum roka izrade ne može biti pre današnjeg datuma!");
            if (!pravila.ValidirajStatusPlana(statusPlana))
                throw new Exception("Status plana nije validan!");

            return planDB.PlanIzmena(planID, datumRokaIzrade, statusPlana);
        }

        public bool PlanBrisanje(int  planID)
        {
            return planDB.PlanBrisanje(planID);
        }
    }
}
