namespace OpenInApp.Menu
{
    public interface IGeneralOptionsBase
    {
        string ActualPathToExe { get; set; }
        string FileQuantityWarningLimit { get; set; }
        //bool SuppressTypicalFileExtensionsWarning { get; set; }
        //string TypicalFileExtensions { get; set; }

        void LoadSettingsFromStorage();
        void PersistVSToolOptions(string fileName);
    }
}
