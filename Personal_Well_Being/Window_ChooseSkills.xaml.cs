using System.Windows;
using System.Windows.Controls;

namespace Personal_Well_Being
{
    /// <summary>
    /// Interaction logic for Window_ChooseSkills.xaml
    /// </summary>
    public partial class Window_ChooseSkills : Window
    {
        public Window_ChooseSkills()
        {
            InitializeComponent();
        }

        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            this.Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
