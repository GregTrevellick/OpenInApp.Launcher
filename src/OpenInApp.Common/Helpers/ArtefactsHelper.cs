using OpenInApp.Common.Helpers.Dtos;
using System.Collections.Generic;
using System.IO;

namespace OpenInApp.Common.Helpers
{
    public static class ArtefactsHelper 
    {
        /// <summary>
        /// Checks if a specified artefact exists on disc.
        /// </summary>
        /// <param name="fullExecutableFileName">Full name of the artefact.</param>
        /// <returns></returns>
        public static bool DoesActualPathToExeExist(string fullExecutableFileName)
        {
            return DoArtefactsExist(new List<string> { fullExecutableFileName });
        }

        /// <summary>
        /// Checks if all specified artefacts exists on disc.
        /// </summary>
        /// <param name="fullArtefactNames">The full artefact names.</param>
        /// <returns></returns>
        public static bool DoArtefactsExist(IEnumerable<string> fullArtefactNames, ArtefactTypeToOpen artefactTypeToOpen = ArtefactTypeToOpen.File)
        {
            var result = true;

            foreach (var fullArtefactName in fullArtefactNames)
            {
                if (string.IsNullOrEmpty(fullArtefactName))
                {
                    result = false;
                }
                else
                {
                    switch (artefactTypeToOpen)
                    {
                        case ArtefactTypeToOpen.File:
                            if (!File.Exists(fullArtefactName))
                            {
                                result = false;
                            }
                            break;
                        case ArtefactTypeToOpen.Folder:
                            if (!Directory.Exists(fullArtefactName))
                            {
                                result = false;
                            }
                            break;
                    }
                }
            }

            return result;
        }
    }
}
