using CrimeReportingSystem.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrimeReportingSystemAPP.Entity
{
    internal class CaseReport
    {
        Incidents _incidentdetails;
        Evidence _evidencedetails;
        Victims _victimdetails;
        Suspects _suspectdetails;
        Reports _reportdetails;
        LawEnforcementAgencies _agencydetails;
        Officers _officerdetails;

        public Incidents IncidentDetails
        {
            get { return _incidentdetails; }
            set { _incidentdetails = value; }
        }
        public Evidence EvidenceDetails
        {
            get { return _evidencedetails; }
            set { _evidencedetails = value; }
        }
        public Victims VictimDetails
        {
            get { return _victimdetails; }
            set { _victimdetails = value; }
        }
        public Suspects SuspectDetails
        {
            get { return _suspectdetails; }
            set { _suspectdetails = value; }
        }
        public Reports ReportDetails
        { 
        get { return _reportdetails; }
            set { _reportdetails = value; }
        }
        public LawEnforcementAgencies AgencyDetails 
        {
            get { return _agencydetails; }
            set { _agencydetails = value; }
        }
        public Officers OfficerDetails
        {
            get { return _officerdetails; }
            set { _officerdetails = value; }
        }

        public override string ToString()
        {
            return $"Case Report:\n" +
                   $"Incident Details: {IncidentDetails}\n" +
                   $"Evidence Details: {EvidenceDetails}\n" +
                   $"Victim Details: {VictimDetails}\n" +
                   $"Suspect Details: {SuspectDetails}\n" +
                   $"Report Details: {ReportDetails}\n" +
                   $"Agency Details: {AgencyDetails}\n" +
                   $"Officer Details: {OfficerDetails}\n\n"+


                   $"Incident Details:\n" +
                   $"- Type: {IncidentDetails.IncidentType}\n" +
                   $"- Date: {IncidentDetails.IncidentDate.ToString("yyyy-MM-dd")}\n" +
                   $"- Location: {IncidentDetails.Location}\n" +
                   $"- Description: {IncidentDetails.Description}\n" +
                   $"- Status: {IncidentDetails.Status}\n\n" +

                   $"Victim Details:\n" +
                   $"- Name: {VictimDetails.FirstName} {VictimDetails.LastName}\n" +
                   $"- Date of Birth: {VictimDetails.DateOfBirth.ToString("yyyy-MM-dd")}\n" +
                   $"- Gender: {VictimDetails.Gender}\n" +
                   $"- Contact Info: {VictimDetails.Contactinformation}\n\n" +

                   $"Suspect Details:\n" +
                   $"- Name: {SuspectDetails.FirstName} {SuspectDetails.LastName}\n" +
                   $"- Date of Birth: {SuspectDetails.DateOfBirth.ToString("yyyy-MM-dd")}\n" +
                   $"- Gender: {SuspectDetails.Gender}\n" +
                   $"- Contact Info: {SuspectDetails.ContactInformation}\n\n" +

                   $"Law Enforcement Agency Details:\n" +
                   $"- Name: {AgencyDetails.AgencyName}\n" +
                   $"- Jurisdiction: {AgencyDetails.Jurisdiction}\n" +
                   $"- Contact Info: {AgencyDetails.ContactInformation}\n\n" +

                   $"Officer Details:\n" +
                   $"- Name: {OfficerDetails.FirstName} {OfficerDetails.LastName}\n" +
                   $"- Badge Number: {OfficerDetails.BadgeNumber}\n" +
                   $"- Rank: {OfficerDetails.Rank}\n" +
                   $"- Contact Info: {OfficerDetails.ContactInformation}\n\n"+

                    $"Evidence Details:\n" +
                   $"- Description: {EvidenceDetails.Description}\n" +
                   $"- Location Found: {EvidenceDetails.LocationFound}\n";


        }


    }
    }
