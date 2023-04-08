using System.Windows;

namespace Personal_Well_Being
{
    /// <summary>
    /// Interaction logic for Window_DefineSkills.xaml
    /// </summary>
    public partial class Window_DefineSkills : Window
    {
        public Window_DefineSkills()
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
