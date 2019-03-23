using System.ComponentModel;

namespace TestMaterial
{
    public enum FormatError
    {
        [Description("No Error")]
        None,

        [Description("Empty File")]
        EmptyFile,

        [Description("Option start tag missing")]
        OptionStartTagMissing,

        [Description("Option end tag missing")]
        OptionEndTagMissing,

        [Description("More than one option start tag found")]
        MultipleOptionStartTagFound,

        [Description("More than one option end tag found")]
        MultipleOptionEndTagFound,

        [Description("Question attributes missing")]
        AttrbsMissing,

        [Description("Difficulty level attribute missing")]
        DifficultyLevelMissing,

        [Description("Category ID attribute missing")]
        CategoryIdMissing,

        [Description("Formatting error in question attributes." +
            "or more than expected question attributes found")]
        AttribFormatError
    }
}
