using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using Newtonsoft.Json;

namespace JsonWrapper
{
    public class JsonUtil
    {
        public static Object GetDeserializedObject(string fileFullName)
        {
            Object items;


            using (StreamReader r = new StreamReader(fileFullName))
            {
                string json = r.ReadToEnd();
                items = JsonConvert.DeserializeObject(json);
            }

            return items;
        }

    }
}
