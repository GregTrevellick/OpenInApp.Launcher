using Microsoft.VisualStudio.Shell;
using OpenInApp.Command;
using OpenInApp.Common.Helpers;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using OpenInApp.Menu;

namespace OpenInVS2013.Options.VS2013
{
    public class GeneralOptions : DialogPage, IGeneralOptionsFile // or set to IGeneralOptionsFolder
    {
        internal static KeyToExecutableEnum keyToExecutableEnum = KeyToExecutableEnum.VS2013;
        private IEnumerable<string> defaultTypicalFileExtensions = new ConstantsForAppCommon().GetDefaultTypicalFileExtensions(keyToExecutableEnum);
        private const string CommonActualPathToExeOptionLabel = CommonConstants.ActualPathToExeOptionLabelPrefix + KeyToExecutableString.VS2013;

        [Category(CommonConstants.CategorySubLevel)]
        [DisplayName(CommonActualPathToExeOptionLabel)]
        [Description(CommonConstants.ActualPathToExeOptionDetailedDescription)]
        public string ActualPathToExe { get; set; }

        [Category(CommonConstants.CategorySubLevel)]
        [DisplayName(CommonConstants.TypicalFileExtensionsOptionLabel)]
        [Description(CommonConstants.TypicalFileExtensionsOptionDetailedDescription)]
        // Set to 'internal' to hide in IDE Options (e.g. TreeSizeFree)
        public string TypicalFileExtensions
        {
            get
            {
                if (string.IsNullOrEmpty(typicalFileExtensions))
                {
                    return AllAppsHelper.GetDefaultTypicalFileExtensionsAsCsv(defaultTypicalFileExtensions);
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
        // Set to 'internal' to hide in IDE Options (e.g. TreeSizeFree)
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
                        new ConstantsForAppCommon().Caption,
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
                TypicalFileExtensions = AllAppsHelper.GetDefaultTypicalFileExtensionsAsCsv(defaultTypicalFileExtensions);
            }

            if (string.IsNullOrEmpty(ActualPathToExe))
            {
                ActualPathToExe = GeneralOptionsHelper.GetActualPathToExe(keyToExecutableEnum);
            }

            previousActualPathToExe = ActualPathToExe;
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
                if (!AllAppsHelper.DoesActualPathToExeExist(ActualPathToExe))
                {
                    e.ApplyBehavior = ApplyKind.Cancel;

                    var caption = new ConstantsForAppCommon().Caption;

                    var filePrompterHelper = new FilePrompterHelper(caption, keyToExecutableEnum.Description());

                    var persistOptionsDto = filePrompterHelper.PromptForActualExeFile(ActualPathToExe);

                    if (persistOptionsDto.Persist)
                    {
                        PersistVSToolOptions(persistOptionsDto.ValueToPersist);
                    }
                }
            }

            base.OnApply(e);
        }

        public void PersistVSToolOptions(string fileName)
        {
            VSPackage.Options.ActualPathToExe = fileName;
            VSPackage.Options.SaveSettingsToStorage();
        }
    }
}