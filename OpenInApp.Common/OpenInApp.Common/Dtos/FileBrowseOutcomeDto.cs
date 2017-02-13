using System.Windows.Forms;

namespace OpenInApp.Common.Dtos
{
    /// <summary>
    /// Dto for file browsing in the file system
    /// </summary>
    public class FileBrowseOutcomeDto
    {
        /// <summary>
        /// The selected dialog result
        /// </summary>
        public DialogResult DialogResult { get; set; }
        
        /// <summary>
        /// The chosen file name
        /// </summary>
        public string FileNameChosen { get; set; }
    }
}

