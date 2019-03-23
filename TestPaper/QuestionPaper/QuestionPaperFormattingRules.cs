using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace TestMaterial
{
    [JsonObject]
    public class QuestionPaperFormattingRules
    {
        [JsonProperty("QuestionSeparator")]
        public string QuestionSeparator { get; set; }

        [JsonProperty("OptionSeparator")]
        public string OptionSeparator { get; set; }

        [JsonProperty("Option")]
        public string OptionIdentifier { get; set; }

        [JsonProperty("OptionEnd")]
        public string EndOfOption { get; set; }

        [JsonProperty("Image")]
        public string ImageIdentifier { get; set; }

        [JsonProperty("ImageEnd")]
        public string EndOfImage { get; set; }

        [JsonProperty("Text")]
        public string TextIdentifier { get; set; }

        public QuestionPaperFormattingRules()
        {

        }
    }
}
