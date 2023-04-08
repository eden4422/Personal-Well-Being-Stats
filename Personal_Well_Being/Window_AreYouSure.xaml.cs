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
    /// Interaction logic for Window_AreYouSure.xaml
    /// </summary>
    public partial class Window_AreYouSure : Window
    {
        MainWindow mainWindow;

        public Window_AreYouSure(MainWindow mainWindow)
        {
            InitializeComponent();

            this.mainWindow = mainWindow;
        }

        private void YepButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;

            mainWindow.Close();
            this.Close();
        }

        private void NoButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
