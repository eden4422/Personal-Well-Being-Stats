using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
