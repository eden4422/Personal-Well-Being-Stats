using System.Windows;

namespace Personal_Well_Being
{
    /// <summary>
    /// Interaction logic for Window_WriteBiography.xaml
    /// </summary>
    public partial class Window_WriteBiography : Window
    {
        public Window_WriteBiography()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        public string InputBiography { get; set; } = string.Empty;

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
