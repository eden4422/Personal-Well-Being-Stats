using System.Windows;
using System.Windows.Controls;

namespace Personal_Well_Being
{
    /// <summary>
    /// Interaction logic for Page_LandingPage.xaml
    /// </summary>
    public partial class Page_LandingPage : Page
    {
        private MainWindow mainWindow;

        public Page_LandingPage(MainWindow mainWindow)
        {
            InitializeComponent();

            this.mainWindow = mainWindow;
        }

        private void NewGameButton_Click(object sender, RoutedEventArgs e)
        {
            this.mainWindow.ChangePage(new Page_CharacterCreation(this.mainWindow));
        }

        private void LoadGameButton_Click(object sender, RoutedEventArgs e)
        {

        }
        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            this.mainWindow.Close();
        }
    }
}
