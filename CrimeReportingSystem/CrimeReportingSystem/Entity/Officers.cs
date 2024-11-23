using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CrimeReportingSystemAPP.Entity
{
    internal class Officers
    {
        int _officerId;
        string _firstName;
        string _lastName;
        string _badgenum;
        string _rank;
        string _contactinformation;
        int _agencyId;

        public int OfficerID
        {
            get { return _officerId; }
            set { _officerId = value; }
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
        public string BadgeNumber
        {
            get { return _badgenum; }
            set { _badgenum = value; }
        }
        public string Rank
        {
            get { return _rank; }
            set { _rank = value; }
        }
        public string ContactInformation
        {
            get { return _contactinformation; }
            set { _contactinformation = value; }
        }
        public int AgencyID
        {
            get { return _agencyId; }
            set { _agencyId = value; }
        }
        }
    }


  
