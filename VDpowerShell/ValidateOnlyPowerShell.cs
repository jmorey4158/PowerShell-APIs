using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Management.Automation;
using TestValidationDepth;

namespace VDpowerShell
{

    [Cmdlet(VerbsCommon.Get, "NoValidationOnly")]
    public class GetNoValidationOnlyCmdlt : PSCmdlet
    {
        private string _nvonly;
        
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        public string Input
        {
            get { return _nvonly; }
            set { _nvonly = value; }
        }
        protected override void ProcessRecord() 
        {
            DateTime start = DateTime.Now;
            while (DateTime.Now.Subtract(start).Milliseconds < 5) { }
        }
    }



    [Cmdlet(VerbsCommon.Get, "MethodValidationOnly")]
    public class GetMethodValidationOnlyCmdlt : PSCmdlet
    {
        private string _mvonly;

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        public string Input
        {
            get { return _mvonly; }
            set
            {
                try
                {
                    Guid.Parse(value);
                    _mvonly = value;
                }
                catch (FormatException fe) { throw fe; }
            }
        }
        protected override void ProcessRecord()
        {
            DateTime start = DateTime.Now;
            while (DateTime.Now.Subtract(start).Milliseconds < 5) { }
        }
    }



    [Cmdlet(VerbsCommon.Get, "NullValidationOnly")]
    public class GetNullValidationOnlyCmdlt : PSCmdlet
    {
        private string _uvonly;

        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        public string Input
        {
            get { return _uvonly; }
            set { _uvonly = value; }
        }

        protected override void ProcessRecord()
        {
            DateTime start = DateTime.Now;
            while (DateTime.Now.Subtract(start).Milliseconds < 5) { }
        }
    }



    [Cmdlet(VerbsCommon.Get, "PatternValidationOnly")]
    public class GetPatternValidationOnlyCmdlt : PSCmdlet
    {
        private string _pvonly;

        [ValidatePattern("^[A-Za-z0-9]{8}-[A-Za-z0-9]{4}-[A-Za-z0-9]{4}-[A-Za-z0-9]{4}-[A-Za-z0-9]{12}$")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        public string Input
        {
            get { return _pvonly; }
            set { _pvonly = value; }
        }
        protected override void ProcessRecord()
        {
            DateTime start = DateTime.Now;
            while (DateTime.Now.Subtract(start).Milliseconds < 5) { }
        }
    }



    [Cmdlet(VerbsCommon.Get, "ClassValidationOnly")]
    public class GetClassValidationOnlyCmdlt : PSCmdlet
    {
        private string _cvonly;

        [ValidateGuidOld]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        public string Input
        {
            get { return _cvonly; }
            set { _cvonly = value; }
        }
        protected override void ProcessRecord()
        {
            DateTime start = DateTime.Now;
            while (DateTime.Now.Subtract(start).Milliseconds < 5) { }
        }
    }



    [Cmdlet(VerbsDiagnostic.Test, "DescriptionValidation")]
    public class TestDescriptionValidationCmdlt : PSCmdlet
    {

        [ValidateDescriptionShortAttribute]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        public string UserDescription
        {
            get ; 
            set ;
        }


        protected override void ProcessRecord()
        {
            try
            {
                ShallowAPI sapi = new ShallowAPI();
                string result = sapi.GetResults(UserDescription);
            }
            catch (FormatException fe) { throw fe; }
            catch (Exception e) { }
        }

    }
}
