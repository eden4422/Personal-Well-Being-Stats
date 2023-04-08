using System.Windows;

namespace Personal_Well_Being
{
    /// <summary>
    /// Interaction logic for Window_UploadPicture.xaml
    /// </summary>
    public partial class Window_UploadPicture : Window
    {
        public Window_UploadPicture()
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
