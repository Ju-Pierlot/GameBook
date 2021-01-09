using System.Windows;

namespace GameBook.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Minimize.Click += (o, e) => WindowState = WindowState.Minimized;
            Quit.Click += (o, e) => Close();
        }
    }
}
