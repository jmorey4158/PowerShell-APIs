using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VDpowerShell
{
    public class UserDescription
    {
        private string _desc;
        public UserDescription() { }

        public UserDescription(String desc)
        {
            _desc = desc;

        }

        [ValidateDescriptionShortAttribute]
        public String Description
        {
            get { return _desc; }
            set { _desc = value; }
        }

    }
}
