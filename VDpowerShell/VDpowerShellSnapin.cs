using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Management;
using System.Management.Automation;

namespace VDpowerShell
{
    //[RunInstaller(true)]
    public class VDpowerShellSnapin
    {
        public VDpowerShellSnapin(){}

        /// <summary>
        /// Gets description of powershell snap-in.
        /// </summary>
        public string Description
        {
            get { return "The VDpowerShellSnapin class provide custom validation Atrtributes for testing performance."; }
        }

        /// <summary>
        /// Gets name of power shell snap-in
        /// </summary>
        public string Name
        {
            get { return "VDpowerShellSnapin"; }
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
