using System.Windows.Forms;
using DesktopVotingModuleViewModel;

namespace DesktopVotingModule
{
    public class FolderBrowser : IBrowse
    {
        public string Browse()
        {
            string path = "";
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    path = fbd.SelectedPath;
                }
                else
                {
                    path = "Błędna ścieżka!";
                }
            }

            return path;
        }
    }
}