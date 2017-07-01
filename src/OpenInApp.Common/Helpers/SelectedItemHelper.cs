using EnvDTE;

namespace OpenInApp.Common.Helpers
{
    public class SelectedItemHelper
    {
        public static string GetFolderSelectedFullPath(SelectedItem selectedItem)
        {
            return selectedItem.ProjectItem.FileNames[0];
        }
    }
}
