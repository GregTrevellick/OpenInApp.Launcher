using EnvDTE;
using EnvDTE80;
using OpenInApp.Common.Helpers.Dtos;
using System.Collections.Generic;

namespace OpenInApp.Common.Helpers
{
    public class ArtefactsToOpenHelper
    {
        public static ArtefactsToBeOpened GetArtefactsToBeOpened(DTE2 dte, IEnumerable<string> allowedFileExtensions, CommandPlacement commandPlacement,  ArtefactTypeToOpen artefactTypeToOpen)
        {
            var result = new ArtefactsToBeOpened();

            //do stuff

            RemoveAnyFilesOfIncorrectType(result.FilesToBeOpened, allowedFileExtensions);
            return result;
        }

        private static string GetActiveDocumentArtefactName(DTE2 dte)//SetArtefactNamesToBeOpened_CodeWin
        {
            //////dte.ActiveDocument.Save();
            return dte.ActiveDocument.FullName;
        }

        private static IEnumerable<string> GetSelectedItemsArtefactNames(DTE2 dte)//SetArtefactNamesToBeOpened_ItemNode
        {
            var result = new List<string>();

            foreach (SelectedItem selectedItem in dte.SelectedItems)
            {
                result.Add(SelectedItemHelper.GetFolderSelectedFullPath(selectedItem));
            }

            return result;
        }

        private static void RemoveAnyFilesOfIncorrectType(IEnumerable<string> filesToBeOpened, IEnumerable<string> allowedFileExtensions)
        {
            //do stuuf
        }
    }
}
