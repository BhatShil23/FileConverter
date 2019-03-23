using System;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using TestMaterial;

namespace TestFileConvertorConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Config config = null;
            try
            {
                using (StreamReader r = new StreamReader(NamedValue.AppConfigFile))
                {
                    string json = r.ReadToEnd();
                    config = JsonConvert.DeserializeObject<Config>(json);
                }

                TestFileConvertor fileConvertor = new TestFileConvertor(config);
                fileConvertor.Convert();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                Console.WriteLine("Refer log file for more detaiils." + TestFileConvertor.logFile);
            }
            finally
            {
                if (File.Exists(TestFileConvertor.logFile))
                {
                    File.Delete(TestFileConvertor.logFile);
                }

                File.WriteAllLines(TestFileConvertor.logFile, TestFileConvertor.logData);
            }
        }
    }
}
