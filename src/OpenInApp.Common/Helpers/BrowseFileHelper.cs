using OpenInApp.Common.Helpers.Dtos;
using System;
using System.Windows.Forms;

namespace OpenInApp.Common.Helpers
{
    public class BrowseFileHelper
    {
        /// <summary>
        /// Prompts the user to browses for a file on disc and returns details.
        /// </summary>
        /// <param name="executableFileToBrowseFor">The executable file to browse for.</param>
        /// <returns></returns>
        public static FileBrowseOutcomeDto BrowseToFileLocation(string executableFileToBrowseFor)
        {
            var dialog = new OpenFileDialog
            {
                DefaultExt = ".exe",
                FileName = executableFileToBrowseFor,
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles),
                CheckFileExists = true
            };

            var dialogResult = dialog.ShowDialog();

            return new FileBrowseOutcomeDto
            {
                FileNameChosen = dialog.FileName,
                DialogResult = dialogResult
            };
        }

    }
}
