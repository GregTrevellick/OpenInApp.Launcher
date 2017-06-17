namespace OpenInApp.Menu
{
    public interface IGeneralOptionsFile : IGeneralOptionsBase
    {
        //string ActualPathToExe { get; set; }
        //string FileQuantityWarningLimit { get; set; }
        bool SuppressTypicalFileExtensionsWarning { get; set; }
        string TypicalFileExtensions { get; set; }

        //void LoadSettingsFromStorage();
        //void PersistVSToolOptions(string fileName);
    }
}
