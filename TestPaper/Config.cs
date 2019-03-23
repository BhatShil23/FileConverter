using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TestMaterial
{
    [JsonObject]
    public class Config
    {
        [JsonProperty("FileConversion")]
        [JsonConverter(typeof(StringEnumConverter))]
        public FileConversionOption FileConversionOption { get; set; }

        [JsonProperty("Input")]
        public string Input { get; set; }

        [JsonProperty("OverwriteOutputFile")]
        public FileOverWriteFlag OverwriteOutputFile { get; set; }
    }
}

