namespace OpenInApp.Menu
{
    public interface IGeneralOptionsFile : IGeneralOptionsBase
    {
        bool SuppressTypicalFileExtensionsWarning { get; set; }
        string TypicalFileExtensions { get; set; }
    }
}
