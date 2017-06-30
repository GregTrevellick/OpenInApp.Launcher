using System.Collections.Generic;
using System.Text;

namespace OpenInApp.Common.Helpers
{
    public class AllAppsHelper
    {
        /// <summary>
        /// Checks if a specified artefact exists on disc.
        /// </summary>
        /// <param name="fullExecutableFileName">Full name of the artefact.</param>
        /// <returns></returns>
        public static bool DoesActualPathToExeExist(string fullExecutableFileName)
        {
            return CommonFileHelper.DoArtefactsExist(new List<string> { fullExecutableFileName });
        }

        /// <summary>
        /// Gets the typical file extensions as a CSV string.
        /// </summary>
        /// <param name="defaultExts">The default exts.</param>
        /// <returns></returns>
        public static string GetDefaultTypicalFileExtensionsAsCsv(IEnumerable<string> defaultExts)
        {
            var stringBuilder = new StringBuilder();
            foreach (var defaultExt in defaultExts)
            {
                stringBuilder.Append(defaultExt).Append(',');
            }
            return stringBuilder.ToString().TrimEnd(',');
        }
    }
}
