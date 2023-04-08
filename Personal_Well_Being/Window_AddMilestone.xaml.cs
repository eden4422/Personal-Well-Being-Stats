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
    /// Interaction logic for Window_AddMilestone.xaml
    /// </summary>
    public partial class Window_AddMilestone : Window
    {
        public string mileStoneDescription;

        public Window_AddMilestone()
        {
            InitializeComponent();
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;

            mileStoneDescription = milestoneDescription.Text;

            this.Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
