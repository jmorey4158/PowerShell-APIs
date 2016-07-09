using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCmdlet
{
    public static class ValidateArgs
    {
        public static Boolean IsValidGuid(String _id)
        {
            try
            {
                Guid.Parse(_id);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }



        public static Boolean IsValidShortDescription(String _desc)
        {
            if (!String.IsNullOrEmpty(_desc))
            {
                if((_desc.Length >= 1) &&(_desc.Length <= 2000))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
