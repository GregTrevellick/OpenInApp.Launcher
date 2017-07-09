using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace OpenInApp.Common.Helpers
{
    public static class CsvHelper
    {
        public static IEnumerable<string> GetTypicalFileExtensionAsList(string typicalFileExtensionsAsCsv)
        {
            if (string.IsNullOrEmpty(typicalFileExtensionsAsCsv))
            {
                return new List<string>();
            }
            else
            {
                return typicalFileExtensionsAsCsv.Split(',');
            }
        }

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

        internal static IEnumerable<string> GetFileTypeExtensions(IEnumerable<string> fullFileNames)
        {
            var result = new List<string>();

            if (fullFileNames != null)
            {
                foreach (var fullFileName in fullFileNames)
                {
                    var ext = Path.GetExtension(fullFileName);

                    if (!string.IsNullOrEmpty(ext))
                    {
                        result.Add(ext);
                    }
                }
            }

            return result;
        }
    }
}
