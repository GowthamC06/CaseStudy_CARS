namespace CrimeReportingSystemAPP.Entity
{
    internal class Victims
    {
        int _victimId;
        string _firstName;
        string _lastName;
        DateTime _dateofbirth;
        string _gender;
        string _contactinformation;
        public int VictimID
        {
            get { return _victimId; }
            set { _victimId = value; }
        }
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }
        public DateTime DateOfBirth 
        {
            get { return _dateofbirth; }
            set { _dateofbirth = value; }
        }
        public string Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }
        public string Contactinformation
        {
            get { return _contactinformation; }
            set { _contactinformation = value; }
        }

    }
}
