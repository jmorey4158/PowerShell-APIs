using System.Management.Automation;
using System;
using System.Collections;

namespace TestCmdlet
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public sealed class ValidateGuidAttribute : ValidateArgumentsAttribute
    {
        public ValidateGuidAttribute() { }
        protected override void Validate(Object arguments, EngineIntrinsics engineIntrinsics)
        {
            if (! ValidateArgs.IsValidGuid(arguments.ToString()))
            {
                InvocationInfo myCmdlet = (InvocationInfo)engineIntrinsics.SessionState.PSVariable.Get("MyInvocation").Value;
                CommandInfo cmdInfo = myCmdlet.MyCommand;

                String message = "ValidateGuid : Invalid parameter value. The value must be a valid GUID.";
                String recommendedAction = "You can get this by using $var = [guid]::NewGuid or by entering the string representation of a valid GUID. Try the command again using the correct input value.";
                String reason = "Invalid parameter value. The value must be a valid GUID.";
                String activity = "Parameter Validation";
                String target = cmdInfo.ToString().Replace("\"", " '");
                String targetType = "String";


                ValidationError.ThrowTerminatingError(message, recommendedAction, reason, activity, target, targetType);
            }
        }
    }



    [AttributeUsageAttribute(AttributeTargets.Property)]
    public sealed class ValidateShortDescriptionAttribute : ValidateArgumentsAttribute
    {
        public ValidateShortDescriptionAttribute() { }
        protected override void Validate(Object arguments, EngineIntrinsics engineIntrinsics)
        {
            if (!ValidateArgs.IsValidShortDescription(arguments.ToString()))
            {
                InvocationInfo myCmdlet = (InvocationInfo)engineIntrinsics.SessionState.PSVariable.Get("MyInvocation").Value;

                String message = "ValidateShortDescription : Invalid parameter value. The value must be a valid Description 1-2000 characters long.";
                String recommendedAction = "Try the command again using the correct input value.";
                String reason = "Invalid parameter value. The value must be a valid Description 1-2000 characters long.";
                String activity = "Parameter Validation";
                String target = myCmdlet.MyCommand.ToString().Replace("\"", " '");
                String targetType = "String";

                ValidationError.ThrowTerminatingError(message, recommendedAction, reason, activity, target, targetType);
            }
        }
    }


    [AttributeUsageAttribute(AttributeTargets.Property)]
    public sealed class ValidateMediumDescriptionAttribute : ValidateArgumentsAttribute
    {
        public ValidateMediumDescriptionAttribute() { }
        protected override void Validate(Object arguments, EngineIntrinsics engineIntrinsics)
        {
            if (!ValidateArgs.IsValidShortDescription(arguments.ToString()))
            {
                InvocationInfo myCmdlet = (InvocationInfo)engineIntrinsics.SessionState.PSVariable.Get("MyInvocation").Value;

                String message = "ValidateShortDescription : Invalid parameter value. The value must be a valid Description 1-10000 characters long.";
                String recommendedAction = "Try the command again using the correct input value.";
                String reason = "Invalid parameter value. The value must be a valid Description 1-10000 characters long.";
                String activity = "Parameter Validation";
                String target = myCmdlet.MyCommand.ToString().Replace("\"", " '");
                String targetType = "String";

                ValidationError.ThrowTerminatingError(message, recommendedAction, reason, activity, target, targetType);
            }
        }
    }


    [AttributeUsageAttribute(AttributeTargets.Property)]
    public sealed class ValidateLongDescriptionAttribute : ValidateArgumentsAttribute
    {
        public ValidateLongDescriptionAttribute() { }
        protected override void Validate(Object arguments, EngineIntrinsics engineIntrinsics)
        {
            if (!ValidateArgs.IsValidShortDescription(arguments.ToString()))
            {
                InvocationInfo myCmdlet = (InvocationInfo)engineIntrinsics.SessionState.PSVariable.Get("MyInvocation").Value;

                String message = "ValidateShortDescription : Invalid parameter value. The value must be a valid Description 1-100000 characters long.";
                String recommendedAction = "Try the command again using the correct input value.";
                String reason = "Invalid parameter value. The value must be a valid Description 1-100000 characters long.";
                String activity = "Parameter Validation";
                String target = myCmdlet.MyCommand.ToString().Replace("\"", " '");
                String targetType = "String";

                ValidationError.ThrowTerminatingError(message, recommendedAction, reason, activity, target, targetType);
            }
        }
    }



    [AttributeUsageAttribute(AttributeTargets.Property)]
    public class ValidateIdListAttribute : ValidateEnumeratedArgumentsAttribute
    {
        public ValidateIdListAttribute() { }
        protected override void ValidateElement(object element)
        {
            if (!ValidateArgs.IsValidGuid(element.ToString()))
            {
                String message = "ValidateGuid : Invalid parameter value. The value must be a valid GUID.";
                String recommendedAction = "You can get this by using $var = [guid]::NewGuid. Try the command again using the correct input value.";
                String reason = "Invalid parameter value. The value must be a valid GUID.";
                String activity = "Parameter Validation";
                String target = element.ToString();
                String targetType = "String";

                ValidationError.ThrowError(message, recommendedAction, reason, activity, target, targetType);
            }
        }
    }




    [AttributeUsageAttribute(AttributeTargets.Property)]
    public class MyTransformationAttribute : ArgumentTransformationAttribute
    {
        public override Object Transform(EngineIntrinsics engineIntrinsics, Object input)
        {
            // <CODE GOES HERE>
            return new object();
        }
    }




    public static class ValidationError
    {
        public static void ThrowError(String message, String recommendedAction, String reason, String activity, String target, String targetType)
        {
            ValidationMetadataException ve = new ValidationMetadataException(message);

            ErrorRecord er = new ErrorRecord(
                ve,
                message,
                ErrorCategory.InvalidData,
                 ve.Source);

            er.CategoryInfo.Activity = activity;
            er.CategoryInfo.Reason = reason;
            er.CategoryInfo.TargetName = target;
            er.CategoryInfo.TargetType = targetType;

            ErrorDetails ed = new ErrorDetails(message);
            ed.RecommendedAction = recommendedAction;
            er.ErrorDetails = ed;

            new TestValidationCmdlt().WriteError(er);
        }

        public static void ThrowTerminatingError(String message, String recommendedAction, String reason, String activity, String target, String targetType)
        {
            ValidationMetadataException ve = new ValidationMetadataException(message);

            ErrorRecord er = new ErrorRecord(
                ve,
                message,
                ErrorCategory.InvalidData,
                 ve.Source);

            er.CategoryInfo.Activity = activity;
            er.CategoryInfo.Reason = reason;
            er.CategoryInfo.TargetName = target;
            er.CategoryInfo.TargetType = targetType;

            ErrorDetails ed = new ErrorDetails(message);
            ed.RecommendedAction = recommendedAction;
            er.ErrorDetails = ed;

           new TestValidationCmdlt().ThrowTerminatingError(er);
        }

        public static void DisplayError(String message, String recommendedAction, String reason, String activity, String target, String targetType)
        {
            ValidationMetadataException ve = new ValidationMetadataException(message);

            ErrorRecord er = new ErrorRecord(
                ve,
                message,
                ErrorCategory.InvalidData,
                 ve.Source);

            er.CategoryInfo.Activity = activity;
            er.CategoryInfo.Reason = reason;
            er.CategoryInfo.TargetName = target;
            er.CategoryInfo.TargetType = targetType;

            ErrorDetails ed = new ErrorDetails(message);
            ed.RecommendedAction = recommendedAction;
            er.ErrorDetails = ed;

            ResolveValidationErrorCmdlt ner = new ResolveValidationErrorCmdlt();
            ner.Error = er;

            IEnumerable results = ner.Invoke();
            foreach (var x in results) { }
        }

    }
}