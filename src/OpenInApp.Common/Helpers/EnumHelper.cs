using System;
using System.Linq;

namespace OpenInApp.Common.Helpers
{
    //http://stackoverflow.com/questions/1799370/getting-attributes-of-enums-value

    public static class EnumerationExtension
    {
        public static string Description(this Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attributes = field.GetCustomAttributes(false);

            // Description is in a hidden Attribute class called DisplayAttribute. Not to be confused with DisplayNameAttribute.
            dynamic displayAttribute = null;

            if (attributes.Any())
            {
                displayAttribute = attributes.ElementAt(0);
            }

            return displayAttribute?.Description ?? "Description Not Found";
        }
    }
}
