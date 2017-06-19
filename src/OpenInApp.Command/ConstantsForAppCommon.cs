using OpenInApp.Common.Helpers;
using System.Collections.Generic;

namespace OpenInApp.Command
{
    public class ConstantsForAppCommon
    {
        private string _vsixName;
        private string _vsixVersion;

        public ConstantsForAppCommon()
        {
        }

        public ConstantsForAppCommon(string vsixName, string vsixVersion)
        {
            _vsixName = vsixName;
            _vsixVersion = vsixVersion;
        }

        public string Caption 
        { 
            get 
                { 
                    return _vsixName + " " + _vsixVersion;
                }
        }

        public IEnumerable<string> GetDefaultTypicalFileExtensions(KeyToExecutableEnum keyToExecutableEnum)
        {
            return new ApplicationToOpenHelper().GetApplicationToOpenDto(keyToExecutableEnum).DefaultTypicalFileExtensions;
        }
    }
}
