using OpenInApp.Common.Helpers.Dtos;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace OpenInApp.Common.Helpers
{
    public class OpenInAppHelper
    {
        public static void InvokeCommand(
            IEnumerable<string> actualArtefactsToBeOpened, 
            string executableFullPath, 
            bool separateProcessPerFileToBeOpened, 
            bool useShellExecute,//gregtt rename to OpenExeWithinItsWorkingDirectory
            ArtefactTypeToOpen artefactTypeToOpen,
            bool processWithinProcess,
            bool wrapArgumentsWithQuotations)
        {
            string fileName;
            string workingDirectory = string.Empty;

            if (useShellExecute)
            {
                fileName = Path.GetFileName(executableFullPath);
                workingDirectory = Path.GetDirectoryName(executableFullPath);
            }
            else
            {
                fileName = executableFullPath;
            }

            if (separateProcessPerFileToBeOpened)
            {
                foreach (var actualArtefactToBeOpened in actualArtefactsToBeOpened)
                {
                    var argument = GetSingleArgument(actualArtefactToBeOpened, wrapArgumentsWithQuotations);
                    InvokeProcess(argument, fileName, useShellExecute, workingDirectory, processWithinProcess);
                }
            }
            else
            {
                var arguments = " ";

                foreach (var actualArtefactToBeOpened in actualArtefactsToBeOpened)
                {
                    arguments += GetSingleArgument(actualArtefactToBeOpened, wrapArgumentsWithQuotations);
                }

                arguments = arguments.TrimEnd(' ');

                InvokeProcess(arguments, fileName, useShellExecute, workingDirectory, processWithinProcess);
            }
        }

        private static string GetSingleArgument(string argument, bool wrapArgumentsWithQuotations)
        {
            var result = string.Empty;

            if (wrapArgumentsWithQuotations)
            {
                result = "\"" + argument + "\"";
            }
            else
            {
                result = argument;
            }

            return result + " ";
        }

        private static void InvokeProcess(string arguments, string fileName, bool useShellExecute, string workingDirectory, bool processWithinProcess)
        {
            var start = new ProcessStartInfo()
            {
                Arguments = arguments,
                CreateNoWindow = true,
                FileName = fileName,
                UseShellExecute = useShellExecute,
                WindowStyle = ProcessWindowStyle.Hidden,
                WorkingDirectory = workingDirectory
            };

            try
            {
                if (processWithinProcess)
                {
                    var startNoArgs = new ProcessStartInfo()
                    {
                        CreateNoWindow = true,
                        FileName = fileName,
                        UseShellExecute = useShellExecute,
                        WindowStyle = ProcessWindowStyle.Hidden,
                        WorkingDirectory = workingDirectory
                    };

                    using (var proc = Process.Start(startNoArgs))
                    {
                        Thread.Sleep(3000);//TODO use async ?
                        using (Process.Start(start)) { }
                    }
                }
                else
                {
                    using (Process.Start(start)) { }
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public static bool ConfirmProceedToExecute(string caption, string messageText)
        {
            bool proceedToExecute = false;

            messageText += 
                Environment.NewLine + Environment.NewLine + 
                CommonConstants.ContinueAnyway + 
                Environment.NewLine + Environment.NewLine + 
                CommonConstants.ToolsOptionsNotice;

            var box = MessageBox.Show(
                messageText,
                caption,
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Warning);

            if (box == DialogResult.OK)
            {
                proceedToExecute = true;
            }

            return proceedToExecute;
        }

        public static void InformUserMissingFile(string caption, string missingFileName)
        {
            MessageBox.Show(
                CommonConstants.InformUserMissingFile(missingFileName),
                caption,
                MessageBoxButtons.OK,
                MessageBoxIcon.Stop);
        }

        public static void ShowUnexpectedError(string caption)
        {
            MessageBox.Show(
                CommonConstants.UnexpectedError,
                caption,
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }
}
