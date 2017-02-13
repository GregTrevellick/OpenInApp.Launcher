using OpenInApp.Common.Helpers;
using System.Windows.Forms;

namespace OpenInAppAltovaXmlSpy.Helpers
{
    public class FileHelper
    {
        public string Caption = Vsix.Name + " " + Vsix.Version;

        public void PromptForActualExeFile(string originalPathToFile)
        {
            var box = MessageBox.Show(
               CommonConstants.PromptForActualExeFile(originalPathToFile),
               Caption,
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question);

            switch (box)
            {
                case DialogResult.Yes:
                    var resultAndNamePicked = CommonFileHelper.BrowseToFileLocation(ConstantsForApp.ExecutableFileToBrowseFor);
                    if (resultAndNamePicked.DialogResult == DialogResult.OK)
                    {
                        PersistVSToolOptions(resultAndNamePicked.FileNameChosen);
                    }
                    break;
                case DialogResult.No:
                    PersistVSToolOptions(originalPathToFile);
                    break;
            }
        }

        private void PersistVSToolOptions(string fileName)
        {
            VSPackage.Options.ActualPathToExe = fileName;
            VSPackage.Options.SaveSettingsToStorage();
        }
    }
}
