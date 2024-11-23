using CrimeReportingSystem.Entity;

namespace CrimeReportingSystemAPP.Entity
{
    internal class Incidents
    {
        int _incidentId;
        string _incidentType;
        DateTime _incidentDate;
        string _location;
        string _incidentDescription;
        string _status;
        int _victimId;
        int _suspectId;
        int _agencyId;

        public int IncidentID
        {
            get { return _incidentId; }
            set { _incidentId = value; }
        }
        public string IncidentType
        {
            get { return _incidentType; }
            set {_incidentType =value; }
        }
        public DateTime IncidentDate
        {
            get {return _incidentDate; }
            set {_incidentDate = value; }
        }
        public string Location
        {
            get { return _location; }
            set { _location = value; }
        }
        public string Description
        {
            get { return _incidentDescription; }
            set { _incidentDescription = value; }
        }
        public string Status
        {
            get {return _status; }
            set {_status = value; }
        }
        public int VictimID
        {
            get { return _victimId; }
            set { _victimId = value; }
        }
        public int SuspectID
        {
            get { return _suspectId; }
            set { _suspectId = value; }
        }
        public int AgencyID
        {
            get { return _agencyId; }
            set { _agencyId = value; }
        }
       
        public override string ToString()
        {
            return $"IncidentId::{IncidentID}\tIncidentType::{IncidentType}\tLocation::{Location}\t" +
                $"Description:{Description}\tStatus::{Status}\tVictimID::{VictimID}\tSuspectID::{SuspectID}\tAgencyID::{AgencyID} ";
        }
    }
}
