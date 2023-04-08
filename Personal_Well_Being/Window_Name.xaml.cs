using System.Windows;

namespace Personal_Well_Being
{
    /// <summary>
    /// Interaction logic for Window_Name.xaml
    /// </summary>
    public partial class Window_Name : Window
    {
        public Window_Name()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        public string InputName { get; set; } = string.Empty;

        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            this.Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void NameInput_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                DialogResult = true;
                this.Close();
            }
        }
    }
}
