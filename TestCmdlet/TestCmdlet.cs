using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Management.Automation;

namespace TestCmdlet
{

    [Cmdlet(VerbsDiagnostic.Test, "Validation")]
    [OutputType(typeof(void))]
    public class TestValidationCmdlt : Cmdlet
    {

        [ValidateGuid]
        [Parameter(Mandatory = true, Position = 0)]
        public string Input { get; set; }



        protected override void ProcessRecord()
        {

            WriteObject("Success! Test-Validate completed with zero errors.");
        }
    }



    [Cmdlet(VerbsDiagnostic.Resolve, "ValidationError")]
    [OutputType(typeof(ErrorRecord))]
    public class ResolveValidationErrorCmdlt : Cmdlet
    {


        [Parameter(Mandatory = true)]
        public ErrorRecord Error { get; set; }



        protected override void ProcessRecord()
        {
            String reason = Error.CategoryInfo.Reason;
            String activity = Error.CategoryInfo.Activity;
            String category = Error.CategoryInfo.Category.ToString();
            String target = Error.CategoryInfo.TargetName;
            String type = Error.CategoryInfo.TargetType;


            String message = Error.Exception.Message;
            String source = Error.Exception.Source;
            String stack = Error.Exception.StackTrace;

            

        }
    }


    [Cmdlet(VerbsCommon.New, "ErrorRecord")]
    [OutputType(typeof(ErrorRecord))]
    public class NewErrorRecordCmdlt : Cmdlet
    {

        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = true)]
        public String ErrorMessage { get; set; }


        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = true)]
        public String Activity { get; set; }


        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = true)]
        public String Category { get; set; }


        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = true)]
        public String Reason { get; set; }


        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = true)]
        public String Target { get; set; }


        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = true)]
        public String TargetType { get; set; }


        [ValidateNotNullOrEmpty]
        [Parameter(Mandatory = true)]
        public String RecommendedAction { get; set; }



        protected override void ProcessRecord()
        {

            ValidationMetadataException ve = new ValidationMetadataException(ErrorMessage);

            ErrorRecord er = new ErrorRecord(
                ve,
                ErrorMessage,
                ErrorCategory.InvalidData,
                 ve.Source);

            er.CategoryInfo.Activity = Activity;
            er.CategoryInfo.Reason = Reason;
            er.CategoryInfo.TargetName = Target;
            er.CategoryInfo.TargetType = TargetType;

            ErrorDetails ed = new ErrorDetails(ErrorMessage);
            ed.RecommendedAction = RecommendedAction;
            er.ErrorDetails = ed;

            WriteObject(er);

        }
    }



    [Cmdlet(VerbsCommon.Get, "UserNameById")]
    [OutputType(typeof(void))]
    public class GetUserNameByIdCmdlt : Cmdlet
    {

        [ValidateGuid]
        [Parameter(Mandatory = true, Position = 0)]
        public string Input { get; set; }



        protected override void ProcessRecord()
        {

            WriteObject("Success! Test-Validate completed with zero errors.");
        }
    }



}