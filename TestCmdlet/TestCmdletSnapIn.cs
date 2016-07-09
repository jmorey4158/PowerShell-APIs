using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCmdlet
{
    public class TestCmdletSnapIn
    {
        public TestCmdletSnapIn() { }

        /// <summary>
        /// Gets description of powershell snap-in.
        /// </summary>
        public string Description
        {
            get { return "The TestCmdletSnapIn class provide custom validation Atrtributes for testing performance."; }
        }

        /// <summary>
        /// Gets name of power shell snap-in
        /// </summary>
        public string Name
        {
            get { return "TestCmdletSnapIn"; }
        }

        /// <summary>
        /// Gets name of the vendor
        /// </summary>
        public string Vendor
        {
            get { return "Microsoft Corp. 2014"; }
        }
    }
}
