using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Management.Automation;

namespace VDpowerShell
{

    [Cmdlet(VerbsCommon.Get, "None")]
    public class GetNoneCmdlt : PSCmdlet
    {
        private string _o;

        [Parameter(Position=0, Mandatory = false, ValueFromPipelineByPropertyName = true)]
        public string Input
        {
            get { return _o; }
            set { _o = value; }
        }
        protected override void ProcessRecord()
        {
            DateTime start = DateTime.Now;
            while (DateTime.Now.Subtract(start).Milliseconds < 5) { }
        }
    }



    [Cmdlet(VerbsCommon.Get, "ProcessRecord")]
    public class GetProcessRecordCmdlt : PSCmdlet
    {
        private string _pr;

        [Parameter(Position = 0, Mandatory = false, ValueFromPipelineByPropertyName = true)]
        public string Input
        {
            get { return _pr; }
            set { _pr = value; }
        }
        protected override void ProcessRecord()
        {
            if (!String.IsNullOrEmpty(_pr ) )
            {
                DateTime start = DateTime.Now;
                while (DateTime.Now.Subtract(start).Milliseconds < 5) { }           
            }
        }
    }



    [Cmdlet(VerbsCommon.Get, "Method")]
    public class GetMethodCmdlt : PSCmdlet
    {
        private string _m;

        [Parameter(Position = 0, Mandatory = false, ValueFromPipelineByPropertyName = true)]
        public string Input
        {
            get { return _m; }
            set 
            {
                if (!String.IsNullOrEmpty(_m))
                {
                    _m = value; 
                }
                
            }
        }
        protected override void ProcessRecord()
        {
            DateTime start = DateTime.Now;
            while (DateTime.Now.Subtract(start).Milliseconds < 5) { }
        }
    }





    [Cmdlet(VerbsCommon.Get, "ClassAttribute")]
    public class GetClassAttributeCmdlt : PSCmdlet
    {
        private string _c;

        [ValidateGuidOld]
        [Parameter(Position = 0, Mandatory = false, ValueFromPipelineByPropertyName = true)]
        public string Input
        {
            get { return _c; }
            set { _c = value; }
        }
        protected override void ProcessRecord()
        {
            DateTime start = DateTime.Now;
            while (DateTime.Now.Subtract(start).Milliseconds < 5) { }
        }
    }


    [Cmdlet(VerbsCommon.Get, "NullAttribute")]
    public class GetNullAttributeCmdlt : PSCmdlet
    {
        private string _n;

        [ValidateNotNullOrEmpty]
        [Parameter(Position = 0, Mandatory = false, ValueFromPipelineByPropertyName = true)]
        public string Input
        {
            get { return _n; }
            set { _n = value; }
        }
        protected override void ProcessRecord()
        {
            DateTime start = DateTime.Now;
            while (DateTime.Now.Subtract(start).Milliseconds < 5) { }
        }
    }


    [Cmdlet(VerbsCommon.Get, "NullAttributeFirst")]
    public class GetNullAttributeFirstCmdlt : PSCmdlet
    {
        private string _nf;

        [ValidateNotNullOrEmpty]
        [ValidateGuidOld]
        [Parameter(Position = 0, Mandatory = false, ValueFromPipelineByPropertyName = true)]
        public string Input
        {
            get { return _nf; }
            set { _nf = value; }
        }
        protected override void ProcessRecord()
        {
            DateTime start = DateTime.Now;
            while (DateTime.Now.Subtract(start).Milliseconds < 5) { }
        }
    }


    [Cmdlet(VerbsCommon.Get, "NullAttributeSecond")]
    public class GetNullAttributeSecondCmdlt : PSCmdlet
    {
        private string _ns;

        [ValidateGuidOld]
        [ValidateNotNullOrEmpty]
        [Parameter(Position = 0, Mandatory = false, ValueFromPipelineByPropertyName = true)]
        public string Input
        {
            get { return _ns; }
            set { _ns = value; }
        }
        protected override void ProcessRecord()
        {
            DateTime start = DateTime.Now;
            while (DateTime.Now.Subtract(start).Milliseconds < 5) { }
        }
    }    


    [Cmdlet(VerbsCommon.Get, "NullAttributeAfter")]
    public class GetNullAttributeAfterCmdlt : PSCmdlet
    {
        private string _nl;

        [Parameter(Position = 0, Mandatory = false, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string Input
        {
            get { return _nl; }
            set { _nl = value; }
        }
        protected override void ProcessRecord()
        {
            DateTime start = DateTime.Now;
            while (DateTime.Now.Subtract(start).Milliseconds < 5) { }
        }
    }


    /// <summary>
    /// TRACING TEST CMDLETS
    /// </summary>

    [Cmdlet(VerbsDiagnostic.Test, "None")]
    public class TestNoneCmdlt : PSCmdlet
    {
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        public string Input
        {
            get;
            set;
        }
        protected override void ProcessRecord() { }
    }
 

    [Cmdlet(VerbsDiagnostic.Test, "Null")]
    public class TestNullCmdlt : PSCmdlet
    {
        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        public string Input
        {
            get;
            set;
        }
        protected override void ProcessRecord() { }
    }


    [Cmdlet(VerbsDiagnostic.Test, "Class")]
    public class TestClassCmdlt : PSCmdlet
    {
        [ValidateGuidOld]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        public string Input
        {
            get;
            set;
        }
        protected override void ProcessRecord() { }
    }


    [Cmdlet(VerbsDiagnostic.Test, "MethodNull")]
    public class TestMethodNullCmdlt : PSCmdlet
    {
        private string _inMethod;
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        public string Input
        {
            get { return _inMethod; }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    _inMethod = value; 
                }
            }
        }
        protected override void ProcessRecord() { }
    }


    [Cmdlet(VerbsDiagnostic.Test, "MethodNGUID")]
    public class TestMethodNGUIDCmdlt : PSCmdlet
    {
        private string _inMethodG;
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        public string Input
        {
            get { return _inMethodG; }
            set
            {
                try
                {
                    Guid.Parse(value);
                    _inMethodG = value;
                }
                catch (FormatException fe) { }
            }
        }
        protected override void ProcessRecord() { }
    }

}

