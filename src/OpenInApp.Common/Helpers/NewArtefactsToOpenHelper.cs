using EnvDTE;
using EnvDTE80;
using OpenInApp.Common.Helpers.Dtos;
using System.Collections.Generic;

namespace OpenInApp.Common.Helpers
{
    public class NewArtefactsToOpenHelper
    {
        public static ArtefactsToBeOpened GetArtefactsToBeOpened(DTE2 dte, IEnumerable<string> allowedFileExtensions, CommandPlacement commandPlacement,  ArtefactTypeToOpen artefactTypeToOpen)
        {
            var result = new ArtefactsToBeOpened();

            switch (commandPlacement)
            {
                case CommandPlacement.IDM_VS_CTXT_CODEWIN:
                    result.FilesToBeOpened = GetActiveDocumentArtefactName(dte);
                    break;
                case CommandPlacement.IDM_VS_CTXT_FOLDERNODE:
                    //do stuuf
                    break;
                case CommandPlacement.IDM_VS_CTXT_ITEMNODE:
                    result.FilesToBeOpened = GetSelectedItemsArtefactNames(dte);
                    break;
                case CommandPlacement.IDM_VS_CTXT_PROJNODE:
                    //do stuuf
                    break;
                default:
                    // ignore ? log as a failed save (to the output window) ? gregtt
                    break;
            }

            RemoveAnyFilesOfIncorrectType(result.FilesToBeOpened, allowedFileExtensions);
            return result;
        }

        private static string GetActiveDocumentArtefactName(DTE2 dte)
        {
            //////dte.ActiveDocument.Save();
            return dte.ActiveDocument.FullName;
        }

        private static IEnumerable<string> GetSelectedItemsArtefactNames(DTE2 dte)
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
