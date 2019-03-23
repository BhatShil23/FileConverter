using System;
using System.Linq;

namespace Common.Util
{
    public class CommonUtil
    {
        public static bool IsEmptyOrWhiteSpace(string value) =>
            value.All(char.IsWhiteSpace);
    }
}
