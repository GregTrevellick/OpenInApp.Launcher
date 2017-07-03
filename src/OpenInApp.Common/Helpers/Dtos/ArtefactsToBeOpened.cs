using System.Collections.Generic;

namespace OpenInApp.Common.Helpers.Dtos
{
    public class ArtefactsToBeOpened 
    {
        public IEnumerable<string> FilesToBeOpened { get; set; }
        public IEnumerable<string> FoldersToBeOpened { get; set; }
    }
}
