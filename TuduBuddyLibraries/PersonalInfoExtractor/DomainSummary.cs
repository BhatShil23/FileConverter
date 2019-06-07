using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuduBuddy.PersonalInfoExtractor
{
    public class DomainSummary
    {
        public string DomainName { get; set; }

        public int Count { get; set; }

        public DomainSummary(string domainName, int count)
        {
            this.DomainName = domainName;
            this.Count = count;
        }
    }
}
