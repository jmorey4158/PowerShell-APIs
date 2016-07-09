using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Management;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Text.RegularExpressions;
using Microsoft.PowerShell.Commands;

namespace VDpowerShell
{
    [AttributeUsageAttribute(AttributeTargets.Property)]
    public sealed class ValidateGuidOld : ValidateArgumentsAttribute
    {
        protected override void Validate(Object arguments, EngineIntrinsics engineIntrinsics)
        {
            if (arguments == null || !(arguments is string))
            {
                ErrorRecord er = new ErrorRecord(
                    new ValidationMetadataException("ValidateGuid : Invalid parameter value. The value must be a valid GUID."),
                    "ValidateGuid : Invalid parameter value. The value must be a valid GUID.",
                    ErrorCategory.InvalidArgument,
                    this);

                new InvokeValidationErrorCmdlt().ThrowTerminatingError(er);
            }
            else
            {
                try
                {
                    Guid.Parse(arguments.ToString());
                }
                catch (FormatException fe) 
                {
                    ErrorDetails ed = new ErrorDetails("The value you input must be the string representation of a valid GUID.");
                    ed.RecommendedAction = "You can get this by using $var = [guid]::NewGuid. Try the command again using the correct input value.";

                    ErrorRecord er = new ErrorRecord(
                        new ValidationMetadataException("ValidateGuid : Invalid parameter value. The value must be a valid GUID."), 
                        "ValidateGuid : Invalid parameter value. The value must be a valid GUID.", 
                        ErrorCategory.InvalidArgument, 
                         fe.Source );
                    er.ErrorDetails = ed;

                     new InvokeValidationErrorCmdlt().ThrowTerminatingError(er);

                }
            }
        }
    }


    [AttributeUsageAttribute(AttributeTargets.Property| AttributeTargets.Parameter)]
    public class ValidateDescriptionShortAttribute : ValidateArgumentsAttribute
    {
        protected override void Validate(Object arguments, EngineIntrinsics engineIntrinsics)
        {
            if (!TestValidationDepth.ValidateDescription.Validate(arguments.ToString(), 1, 2000))
            {
                throw new ValidationMetadataException("Invalid parameter value. The value must be a valid short Description string 1-2,000 characters long.");
            }
        }
    }

    //[AttributeUsageAttribute(AttributeTargets.Property)]
    //public sealed class ValidateListAttribute :  ValidateEnumeratedArgumentsAttribute
    //{
    //    protected override void Validate(object arguments, EngineIntrinsics engineIntrinsics)
    //    {
    //               //<CODE GOES HERE>
    //    }
    // }


    // [AttributeUsageAttribute(AttributeTargets.Property)]
    //public sealed class MyTransformationAttribute : ArgumentTransformationAttribute
    //{
    //    public override Object Transform(EngineIntrinsics engineIntrinsics, Object input)
    //    {
    //                  // <CODE GOES HERE>
    //        return new object();
    //    }
    //}

}