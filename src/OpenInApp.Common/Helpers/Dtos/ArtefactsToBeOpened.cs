using System.Collections.Generic;

namespace OpenInApp.Common.Helpers.Dtos
{
    public class ArtefactsToBeOpened 
    {
        public IList<string> FilesToBeOpened { get; set; }
        public IList<string> FoldersToBeOpened { get; set; }
    }
}
