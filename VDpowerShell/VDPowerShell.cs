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

    [Cmdlet(VerbsCommon.Get, "NoValidation")]
    public class GetNoValidationCmdlt : PSCmdlet
    {
        private string _nvseq;
        private Int32 _nvlim;

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public string Input
        {
            get { return _nvseq ; }
            set { _nvseq = value; }
        }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public Int32 Limit
        {
            get { return _nvlim; }
            set { _nvlim = value; }
        }

        protected override void ProcessRecord()
        {
            for (Int32 i = 0; i < _nvlim; i++)
            {
                try
                {
                    ShallowAPI sapi = new ShallowAPI();
                    string result = sapi.GetResults(_nvseq);
                }
                catch (Exception e) { throw e; }
            }
        }

    }


    [Cmdlet(VerbsCommon.Get, "MethodValidation")]
    public class GetMethodValidationCmdlt : PSCmdlet
    {
        private string _mvseq;
        private Int32 _mvlim;

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public string Input
        {
            get { return _mvseq; }
            set {
                    try
                    {
                        Guid.Parse(value);
                        _mvseq = value;
                    }
                    catch (Exception e) { throw e; }
                 }
        }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public Int32 Limit
        {
            get { return _mvlim; }
            set { _mvlim = value; }
        }

        protected override void ProcessRecord()
        {
            for (Int32 i = 0; i < _mvlim; i++)
            {
                try
                {
                    ShallowAPI sapi = new ShallowAPI();
                    string result = sapi.GetResults(_mvseq);
                }
                catch (Exception e) { throw e; }
            }
        }

    }


    [Cmdlet(VerbsCommon.Get, "NullValidation")]
    public class GetNullValidationCmdlt : PSCmdlet
    {
        private string _uvseq;
        private Int32 _uvlim;

        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public string Input
        {
            get { return _uvseq; }
            set { _uvseq = value; }
        }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public Int32 Limit
        {
            get { return _uvlim; }
            set { _uvlim = value; }
        }

        protected override void ProcessRecord()
        {
            for (Int32 i = 0; i < _uvlim; i++)
            {
                try
                {
                    ShallowAPI sapi = new ShallowAPI();
                    string result = sapi.GetResults(_uvseq);
                }
                catch (Exception e) { throw e; }
            }
        }

    }


    //[Cmdlet(VerbsCommon.Get, "PatternValidation")]
    //public class GetPatternValidationCmdlt : PSCmdlet
    //{
    //    private string _pvseq;
    //    private Int32 _pvlim;

    //    [ValidatePattern("^[A-Za-z0-9]{8}-[A-Za-z0-9]{4}-[A-Za-z0-9]{4}-[A-Za-z0-9]{4}-[A-Za-z0-9]{12}$")]
    //    [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
    //    public string Input
    //    {
    //        get { return _pvseq; }
    //        set { _pvseq = value; }
    //    }

    //    [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
    //    public Int32 Limit
    //    {
    //        get { return _pvlim; }
    //        set { _pvlim = value; }
    //    }

    //    protected override void ProcessRecord()
    //    {
    //        for (Int32 i = 1; i < _pvlim; i++)
    //        {
    //            try
    //            {
    //                ShallowAPI sapi = new ShallowAPI();
    //                string result = sapi.GetResults(_pvseq);
    //            }
    //            catch (FormatException fe) { }
    //            catch (Exception e) { }
    //        }
    //    }

    //}


    [Cmdlet(VerbsCommon.Get, "ClassValidation")]
    public class GetClassValidationCmdlt : PSCmdlet
    {
        private string _cvseq;
        private Int32 _cvlim;

        [ValidateGuidOld]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public string Input
        {
            get { return _cvseq; }
            set { _cvseq = value; }
        }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public Int32 Limit
        {
            get { return _cvlim; }
            set { _cvlim = value; }
        }

        protected override void ProcessRecord()
        {
            for (Int32 i = 0; i < _cvlim; i++)
            {
                try
                {
                    ShallowAPI sapi = new ShallowAPI();
                    string result = sapi.GetResults(_cvseq);
                }
                catch (Exception e) { throw e; }
            }
        }

    }


    [Cmdlet(VerbsCommon.Get, "GoodInput")]
    public class GetGoodInputCmdlt : PSCmdlet
    {
        protected override void ProcessRecord()
        {
            WriteObject(new Good().GetGood());
        }
    }


    [Cmdlet(VerbsCommon.Get, "SmallBadInput")]
    public class GetSmallBadInputCmdlt : PSCmdlet
    {
        protected override void ProcessRecord()
        {
            WriteObject(new SmallBad().GetSmallInput());
        }
    }


    [Cmdlet(VerbsCommon.Get, "MediumBadInput")]
    public class GeMeduiumInputCmdlt : PSCmdlet
    {
        protected override void ProcessRecord()
        {
            WriteObject(new MediumBad().GetMediumInput());
        }
    }


    [Cmdlet(VerbsCommon.Get, "LargeBadInput")]
    public class GetLargeBadInputCmdlt : PSCmdlet
    {
        protected override void ProcessRecord()
        {
            WriteObject(new MediumBad().GetMediumInput());
        }
    }




    [Cmdlet(VerbsLifecycle.Invoke, "ValidationError")]
    public class InvokeValidationErrorCmdlt : Cmdlet
    {

        [Parameter(Mandatory = false)]
        public ErrorRecord Error
        {
            get;
            set;
        }

        protected override void ProcessRecord() { ThrowTerminatingError(Error); }
    }


    [Cmdlet(VerbsCommon.Get, "ValidateRange")]
    public class GetValidateRangeCmdlt : PSCmdlet
    {
        private Int32 _cvseq;
        private Int32 _cvlim;

        [ValidateRange(1,1000)]
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public Int32 Input
        {
            get { return _cvseq; }
            set { _cvseq = value; }
        }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public Int32 Limit
        {
            get { return _cvlim; }
            set { _cvlim = value; }
        }

        protected override void ProcessRecord()
        {
            for (Int32 i = 0; i < _cvlim; i++)
            {
                try
                {
                    ShallowAPI sapi = new ShallowAPI();
                    string result = sapi.GetResults("Bad");
                }
                catch (Exception e) { throw e; }
            }
        }

    }


}
