using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VDpowerShell;

namespace VDcoreCode
{
    public class CoreClass
    {
        private string _desc;
        public CoreClass() { }

        public Boolean TestCoreClass()
        {
            Boolean _result = false;



            return _result;
        }

        public String Description
        {
            get { return _desc; }
            set { _desc = value; }
        }
    }
}
