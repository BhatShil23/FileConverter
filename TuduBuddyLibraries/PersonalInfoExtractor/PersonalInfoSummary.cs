using System;
using System.Collections.Generic;
using System.Linq;
using Common.Logger;
using TuduBuddyLibraries.Environment;

namespace TuduBuddy.PersonalInfoExtractor
{
    public class PersonalInfoSummary
    {
        readonly private string[] personalInfoData;
        readonly private string delimiter;
        readonly Logger logger = Logger.GetInstance();

        public PersonalInfoSummary(string[] personalInfoRecords, string delimiter)
        {
            this.personalInfoData = personalInfoRecords;
            this.delimiter = delimiter;
        }

        public List<DomainSummary> GetSummary()
        {
            logger.AppendLog("Getting summary..");
            List<PersonalInfo> personalInfoRecords = GetPersonalInfoList();
            List<DomainSummary> domainSummaryList = GetPersonalInfoSummary(personalInfoRecords);
            return domainSummaryList;
        }

        private List<PersonalInfo> GetPersonalInfoList()
        {
            List<PersonalInfo> personalInfoRecords = new List<PersonalInfo>();

            int row = 1;
            foreach (string input in personalInfoData)
            {
                string[] columnData = input.Split(new string[] { delimiter }, StringSplitOptions.None);

                if (columnData.Length < 4)
                {
                    logger.AppendError("Columns in the file is not as expected. "+
                        "Columns missing");
                }
                else
                {
                    logger.AppendLog("Processing row -" + row);
                    personalInfoRecords.Add(new PersonalInfo(columnData[0], columnData[1],
                        columnData[2], columnData[3]));
                }

                row += 1;
            }

            return personalInfoRecords;
        }

        private List<DomainSummary> GetPersonalInfoSummary(List<PersonalInfo> personalInfoList)
        {
            List<string> mailIds = personalInfoList.Select(d => d.Email).ToList();
            List<string> domainIds = new List<string>();

            foreach(string mailId in mailIds)
            {
                if(mailId.Contains(NamedValue.PersonalInfoExtractor.MailIdentifier))
                {
                    string[] splitMailId = mailId.Split(new string[] 
                    { NamedValue.PersonalInfoExtractor.MailIdentifier }, 
                    StringSplitOptions.RemoveEmptyEntries);

                    if((splitMailId[1] != string.Empty) && (!domainIds.Contains(splitMailId[1])))
                    {
                        domainIds.Add(splitMailId[1]);
                    }
                }
            }
            

            List<DomainSummary> personalInfoSummary = new List<DomainSummary>();
            foreach(string domainName in  domainIds)
            {
                int count = personalInfoList.Where(d => d.Email.Contains(domainName)).Count();
                personalInfoSummary.Add(new DomainSummary(domainName, count));
            }

            return personalInfoSummary;
        }
    }
}
