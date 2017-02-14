using Microsoft.VisualStudio.Shell;
using OpenInApp.Common.Helpers;
using OpenInAppAltovaXmlSpy.Helpers;
using System.ComponentModel;
using System.Windows.Forms;

namespace OpenInAppAltovaXmlSpy.Options.AltovaXmlSpy
{
    public class GeneralOptions : DialogPage
    {
        private string Caption { get { return new FileHelper().Caption; } }

        [Category(CommonConstants.CategorySubLevel)]
        [DisplayName(ConstantsForApp.CommonActualPathToExeOptionLabel)]
        [Description(CommonConstants.ActualPathToExeOptionDetailedDescription)]
        public string ActualPathToExe { get; set; }

        [Category(CommonConstants.CategorySubLevel)]
        [DisplayName(CommonConstants.TypicalFileExtensionsOptionLabel)]
        [Description(CommonConstants.TypicalFileExtensionsOptionDetailedDescription)]
        public string TypicalFileExtensions 
        {
            get
            {
                if (string.IsNullOrEmpty(typicalFileExtensions))
                {
                    var defaultTypicalFileExtensions = new ConstantsForApp().GetDefaultTypicalFileExtensions();
                    return CommonFileHelper.GetDefaultTypicalFileExtensionsAsCsv(defaultTypicalFileExtensions);
                }
                else
                {
                    return typicalFileExtensions;
                }
            }
            set
            {
                typicalFileExtensions = value;
            }
        }

        [Category(CommonConstants.CategorySubLevel)]
        [DisplayName(CommonConstants.SuppressTypicalFileExtensionsWarningOptionLabel)]
        [Description(CommonConstants.SuppressTypicalFileExtensionsWarningDetailedDescription)]
        public bool SuppressTypicalFileExtensionsWarning { get; set; } = false;

        [Category(CommonConstants.CategorySubLevel)]
        [DisplayName(CommonConstants.FileQuantityWarningLimitOptionLabel)]
        [Description(CommonConstants.FileQuantityWarningLimitOptionDetailedDescription)]
        public string FileQuantityWarningLimit
        {
            get
            {
                if (string.IsNullOrEmpty(fileQuantityWarningLimit))
                {
                    return CommonConstants.DefaultFileQuantityWarningLimit;
                }
                else
                {
                    return fileQuantityWarningLimit;
                }
            }
            set
            {
                int x;
                var isInteger = int.TryParse(value, out x);
                if (!isInteger)
                {
                    MessageBox.Show(
                        CommonConstants.FileQuantityWarningLimitInvalid,
                        Caption,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                else
                {
                    fileQuantityWarningLimit = value;
                }
            }
        }

        private string fileQuantityWarningLimit;
        private string typicalFileExtensions;

        internal int FileQuantityWarningLimitInt
        {
            get
            {
                int x;
                var isInteger = int.TryParse(FileQuantityWarningLimit, out x);
                if (isInteger)
                {
                    return x;
                }
                else
                {
                    return 0;
                }
            }
        }

        public override void LoadSettingsFromStorage()
        {
            base.LoadSettingsFromStorage();

            if (string.IsNullOrEmpty(TypicalFileExtensions))
            {
                TypicalFileExtensions = GetTypicalFileExtensions();
            }

            if (string.IsNullOrEmpty(ActualPathToExe))
            {
                ActualPathToExe = GeneralOptionsHelper.GetActualPathToExe(
                    ConstantsForApp.AppFolderName, 
                    ConstantsForApp.AppSubFolderName,
                    ConstantsForApp.ExecutableFileToBrowseFor);
            }

            previousActualPathToExe = ActualPathToExe;
        }

        private string GetTypicalFileExtensions()
        {
            return CommonFileHelper.GetDefaultTypicalFileExtensionsAsCsv(new ConstantsForApp().GetDefaultTypicalFileExtensions());
        }

        private string previousActualPathToExe { get; set; }

        protected override void OnApply(PageApplyEventArgs e)
        {
            var actualPathToExeChanged = false;

            if (ActualPathToExe != previousActualPathToExe)
            {
                actualPathToExeChanged = true;
                previousActualPathToExe = ActualPathToExe; 
            }

            if (actualPathToExeChanged)
            {
                if (!CommonFileHelper.DoesFileExist(ActualPathToExe))
                {
                    e.ApplyBehavior = ApplyKind.Cancel;
                    new FileHelper().PromptForActualExeFile(ActualPathToExe);
                }
            }

            base.OnApply(e);
        }
    }
}