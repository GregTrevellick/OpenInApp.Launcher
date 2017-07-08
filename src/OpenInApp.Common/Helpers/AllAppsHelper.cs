using System.Collections.Generic;
using System.Text;

namespace OpenInApp.Common.Helpers
{
    public static class AllAppsHelper
    {
        public static string GetDefaultTypicalFileExtensionsAsCsv(IEnumerable<string> defaultExtensions)
        {
            var stringBuilder = new StringBuilder();

            if (defaultExtensions != null)
            {
                foreach (var defaultExtension in defaultExtensions)
                {
                    stringBuilder.Append(defaultExtension).Append(',');
                }
            }

            return stringBuilder.ToString().TrimEnd(',');
        }
    }
}
