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
using System.Windows.Shapes;

namespace Personal_Well_Being
{
    /// <summary>
    /// Interaction logic for Window_Menu.xaml
    /// </summary>
    public partial class Window_Menu : Window
    {
        MainWindow mainWindow;

        public Window_Menu(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
        }

        private void Continue_Button(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SaveGameButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void StartScreenButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.Close();
            this.Close();
        }
    }
}
