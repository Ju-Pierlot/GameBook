using Microsoft.Win32;

namespace GameBook.Views.ViewModels
{
    public class FileResourceChooser : IChooseResource
    {
        public string ResourceIdentifier
        {
            get
            {
                OpenFileDialog dlg = new OpenFileDialog();

                if (dlg.ShowDialog() == true)
                {
                    return dlg.FileName;
                }
                return string.Empty;
            }
        }
    }
}
