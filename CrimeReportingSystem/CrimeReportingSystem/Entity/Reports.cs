using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrimeReportingSystemAPP.Entity
{
    internal class Reports
    {
        int _reportId;
        int _incidentId;
        int _reportofficerId;
        DateTime _reportdate;
        string _reportdetails;
        string _status;
        Incidents _incidentdetails;
        public int ReportID
        {
            get { return _reportId; }
            set { _reportId = value; }
        }
        public int IncidentID
        {
            get { return _incidentId; }
            set { _incidentId = value; }
        }
        public int ReportingOfficerID
        {
            get { return _reportofficerId; }
            set { _reportofficerId = value; }
        }
        public DateTime ReportDate
        {
            get { return _reportdate; }
            set { _reportdate = value; }
        }
        public string ReportDetails
        {
            get {return _reportdetails; }
            set { _reportdetails = value; }
        }
        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }
        public Incidents IncidentDetails
        {
            get { return _incidentdetails; }
            set { _incidentdetails = value; }
        }

        public override string ToString()
        {
            return $"ReportID: {ReportID}, IncidentID: {IncidentID}, OfficerID: {ReportingOfficerID}, Date: {ReportDate}, Status: {Status}, Details: {ReportDetails}";
        }
    }
}
