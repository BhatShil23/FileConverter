using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

using Newtonsoft.Json;
using TuduBuddyLibraries.Environment;

namespace TuduBuddy.PersonalInfoExtractor
{
    public class PublicDomainConfig
    {
        public List<string> GetPublicDomainList()
        {
            List<string> publicDomainList = new List<string>();

            using (StreamReader r = new StreamReader(NamedValue.PersonalInfoExtractor.PublicDomainConfig))
            {
                string json = r.ReadToEnd();
                dynamic data = JsonConvert.DeserializeObject(json);
                var domainList = data[NamedValue.PersonalInfoExtractor.Domain];

                foreach (string domain in domainList)
                {
                    publicDomainList.Add(domain);
                }
            }

            return publicDomainList;
        }
    }
}
