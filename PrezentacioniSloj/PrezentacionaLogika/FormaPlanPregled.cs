using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using KlasePodataka;

namespace PrezentacionaLogika
{
    public class FormaPlanPregled
    {
        private PlanDB planDB;

        public FormaPlanPregled()
        {
            planDB = new PlanDB();
        }

        public DataSet PlanPrikaz(int planID)
        {
            return planDB.PlanPrikaz(planID);
        }
    }
}
