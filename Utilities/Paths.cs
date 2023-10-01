using System.IO;

namespace Game.Utilities
{
    public static class Paths
    {
        public const string PersistentSettingPath = "Game/Settings/";
        public const string PersistentMainMenu = "Game/";
        public const string UI = "UI/";
        public const string Buttons = "Buttons/";

        public static void OpenInMacFileBrowser(string path)
        {
            bool openInsidesOfFolder = false;

            string macPath = path.Replace("\\", "/");

            if (Directory.Exists(macPath))
            {
                openInsidesOfFolder = true;
            }

            if (!macPath.StartsWith("\""))
            {
                macPath = "\"" + macPath;
            }

            if (!macPath.EndsWith("\""))
            {
                macPath = macPath + "\"";
            }

            string arguments = (openInsidesOfFolder ? "" : "-R ") + macPath;
            try
            {
                System.Diagnostics.Process.Start("open", arguments);
            }
            catch (System.ComponentModel.Win32Exception e)
            {
                e.HelpLink = "";
            }
        }

        public static void OpenInWinFileBrowser(string path)
        {
            bool openInsidesOfFolder = false;

            string winPath = path.Replace("/", "\\");

            if (Directory.Exists(winPath))
            {
                openInsidesOfFolder = true;
            }

            try
            {
                System.Diagnostics.Process.Start("explorer.exe",
                    (openInsidesOfFolder ? "/root," : "/select,") + winPath);
            }
            catch (System.ComponentModel.Win32Exception e)
            {
                e.HelpLink = "";
            }
        }

        public static void OpenInFileBrowser(string path)
        {
            OpenInWinFileBrowser(path);
            OpenInMacFileBrowser(path);
        }
    }
}