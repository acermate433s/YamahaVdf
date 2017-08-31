using System;

namespace YamahaVdf
{
    public class CodeAttribute : Attribute
    {
        public CodeAttribute(string code)
        {
            Code = code;
        }

        public string Code { get; set; }
    }
}
