using System.Collections.Generic;
using System.Text;

namespace OpenInApp.Common.Helpers
{
    public static class AllAppsHelper
    {
         /// <summary>
        /// Gets the typical file extensions as a CSV string.
        /// </summary>
        /// <param name="defaultExtensions">The default exts.</param>
        /// <returns></returns>
        public static string GetDefaultTypicalFileExtensionsAsCsv(IEnumerable<string> defaultExtensions)
        {
            var stringBuilder = new StringBuilder();
            foreach (var defaultExtension in defaultExtensions)
            {
                stringBuilder.Append(defaultExtension).Append(',');
            }
            return stringBuilder.ToString().TrimEnd(',');
        }
    }
}
