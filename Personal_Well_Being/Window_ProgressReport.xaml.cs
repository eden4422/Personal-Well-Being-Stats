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
    /// Interaction logic for Window_ProgressReport.xaml
    /// </summary>
    public partial class Window_ProgressReport : Window
    {
        private MainWindow mainWindow;
        private UserController UC;

        public Window_ProgressReport(MainWindow mainWindow, UserController UC)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
            this.UC = UC;
        }
    }
}
