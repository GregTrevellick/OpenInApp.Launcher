using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace OpenInApp.Common.Helpers
{
    /// <summary>
    /// Helper class containing generic methods for 'OpenInApp' VS packages
    /// </summary>
    public class OpenInAppHelper
    {
        /// <summary>
        /// Invokes the specified executable file, passing the file(s) to be opened as arguments.
        /// </summary>
        /// <param name="actualFilesToBeOpened">The actual files to be opened.</param>
        /// <param name="executableFullPath">The full path to the executable.</param>
        /// <param name="separateProcessPerFileToBeOpened">Whether or not to start a single process or multiple processes for the actual files to be opened.</param> 
        /// <param name="useShellExecute">Whether or not to use shell execution or execute via operating system. Default is true.</param>
        public static void InvokeCommand(IEnumerable<string> actualFilesToBeOpened, string executableFullPath, bool separateProcessPerFileToBeOpened = false, bool useShellExecute = true)
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
                foreach (var actualFileToBeOpened in actualFilesToBeOpened)
                {
                    var argument = GetSingleArgument(actualFileToBeOpened);
                    InvokeProcess(argument, fileName, useShellExecute, workingDirectory);
                }
            }
            else
            {
                var arguments = " ";

                foreach (var actualFileToBeOpened in actualFilesToBeOpened)
                {
                    arguments += GetSingleArgument(actualFileToBeOpened);
                }

                InvokeProcess(arguments, fileName, useShellExecute, workingDirectory);
            }
        }

        private static string GetSingleArgument(string argument)
        {
            return "\"" + argument + "\"" + " ";
        }

        private static void InvokeProcess(string arguments, string fileName, bool useShellExecute, string workingDirectory)
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
                using (Process.Start(start)) { }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        /// <summary>
        /// Displays a simple message box prompting the user to proceed with action or cancel.
        /// </summary>
        /// <param name="caption">The caption.</param>
        /// <param name="messageText">The message text.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Displays a simple message box informing the user of a missing file.
        /// </summary>
        /// <param name="caption">The caption.</param>
        /// <param name="missingFileName">Name of the missing file.</param>
        public static void InformUserMissingFile(string caption, string missingFileName)
        {
            MessageBox.Show(
                CommonConstants.InformUserMissingFile(missingFileName),
                caption,
                MessageBoxButtons.OK,
                MessageBoxIcon.Stop);
        }

        /// <summary>
        /// Displays a simple message box informing the user of an unexpected error.
        /// </summary>
        /// <param name="caption">The caption.</param>
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
