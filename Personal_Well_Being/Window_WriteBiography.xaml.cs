using System.Windows;

namespace Personal_Well_Being
{
    /// <summary>
    /// Interaction logic for Window_WriteBiography.xaml
    /// </summary>
    public partial class Window_WriteBiography : Window
    {
        public string bio;

        public Window_WriteBiography()
        {
            InitializeComponent();
            this.DataContext = this;

            BiographyTextBox.Focus();
        }

        public string InputBiography { get; set; } = string.Empty;

        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            bio = BiographyTextBox.Text;

            DialogResult = true;
            this.Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BiographyTextBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                bio = BiographyTextBox.Text;

                DialogResult = true;
                this.Close();
            }
        }
    }
}
