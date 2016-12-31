using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
