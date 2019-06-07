using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuduBuddy.PersonalInfoExtractor
{
    public class PersonalInfo
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public string GiveName { get; private set; }

        public string Email { get; private set; }

        public PersonalInfo(string firstName, string lastName,
            string givenName, string email)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.GiveName = givenName;
            this.Email = email;
        }
    }
}
