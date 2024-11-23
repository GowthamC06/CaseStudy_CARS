namespace CrimeReportingSystemAPP.Entity
{
    internal class LawEnforcementAgencies
    {
        int _agencyID;
        string _agencyName;
        string _jurisdiction;
        string _contactInformation;
        public int AgencyID
        {
            get { return _agencyID; }
            set { _agencyID = value; }
        }
        public string AgencyName
        {
            get { return _agencyName; }
            set { _agencyName = value; }
        }
        public string Jurisdiction
        {
            get { return _jurisdiction; }
            set { _jurisdiction = value; }
        }
        public string ContactInformation
        {
            get { return _contactInformation; }
            set { _contactInformation = value; }
        }
    }
}
