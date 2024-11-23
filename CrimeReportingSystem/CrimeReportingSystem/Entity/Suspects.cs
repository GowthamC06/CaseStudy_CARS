using CrimeReportingSystemAPP.Entity;

namespace CrimeReportingSystem.Entity
{
    internal class Suspects
    {
        int _suspectId;
        string _firstName;
        string _lastName;
        DateTime _dateofbirth;
        string _gender;
        string _contactinformation;

        public int SuspectID
        {
            get { return _suspectId; }
            set { _suspectId = value; }
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
        public string ContactInformation
        {
            get { return _contactinformation; }
            set { _contactinformation = value; }
        }
    }
}
