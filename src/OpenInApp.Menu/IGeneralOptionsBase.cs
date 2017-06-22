namespace OpenInApp.Menu
{
    public interface IGeneralOptionsBase
    {
        string ActualPathToExe { get; set; }
        string FileQuantityWarningLimit { get; set; }

        void LoadSettingsFromStorage();
        void PersistVSToolOptions(string fileName);
    }
}
