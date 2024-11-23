using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrimeReportingSystemAPP.Entity
{
    internal class Evidence
    {
         int _evidenceID;
        string _description;
        string _locationfound;
         int _incidentID;
        public int EvidenceID
        {
            get { return _evidenceID; }
            set { _evidenceID = value; }
        }

        public string Description 
        {
            get {return _description; }
            set { _description = value; }
        }
        public string LocationFound
        {
            get { return _locationfound; }
            set { _locationfound = value; }
        }
        public int IncidentID
        {
            get { return _incidentID; }
            set { _incidentID = value; }

        }
    }
}
