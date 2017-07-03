using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace OpenInApp.Common.Helpers
{
    public static class CsvHelper
    {
        /// <summary>
        /// Gets the typical file extension as list, from a CSV string.
        /// </summary>
        /// <param name="typicalFileExtensionsAsCsv">The typical file extensions as CSV.</param>
        /// <returns></returns>
        public static IEnumerable<string> GetTypicalFileExtensionAsList(string typicalFileExtensionsAsCsv)
        {
            return typicalFileExtensionsAsCsv.Split(',');
        }

        /// <summary>
        /// Checks if a file extension(s) is a typical file extension for the app, as defined in Tools | Options.
        /// </summary>
        /// <param name="fullFileNames">The full file names.</param>
        /// <param name="typicalFileExtensions">The typical file extensions.</param>
        /// <returns></returns>
        public static bool AreTypicalFileExtensions(IEnumerable<string> fullFileNames, IEnumerable<string> typicalFileExtensions)
        {
            var result = false;

            if (typicalFileExtensions.First() == "*" ||
                fullFileNames == null ||
                fullFileNames.Count() == 0)
            {
                result = true;
            }
            else
            {
                var fileTypeExtensions = GetFileTypeExtensions(fullFileNames);

                foreach (var fileTypeExtension in fileTypeExtensions)
                {
                    if (!string.IsNullOrEmpty(fileTypeExtension))
                    {
                        result = typicalFileExtensions.Contains(fileTypeExtension.TrimStart('.'), StringComparer.CurrentCultureIgnoreCase);
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Gets a collection of file type extensions, from a collection of file names.
        /// </summary>
        /// <param name="fullFileNames">The full file names.</param>
        /// <returns></returns>
        private static IEnumerable<string> GetFileTypeExtensions(IEnumerable<string> fullFileNames)
        {
            var result = new List<string>();

            foreach (var fullFileName in fullFileNames)
            {
                result.Add(Path.GetExtension(fullFileName));
            }

            return result;
        }
    }
}
