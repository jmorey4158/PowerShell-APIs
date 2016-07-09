using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestValidationDepth
{
    public class ValidateDescription
    {
        public static Boolean Validate(String arg, Int32 min, Int32 max)
        {
            Boolean _result = false;
            if (! String.IsNullOrEmpty(arg))
            {
                if ((arg.Length <= max) && (arg.Length >= min))
                {
                    _result =  true;
                }
            }
            return _result;
        }
    }
}
