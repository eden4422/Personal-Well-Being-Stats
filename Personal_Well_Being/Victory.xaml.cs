using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Personal_Well_Being
{
    /// <summary>
    /// Interaction logic for Victory.xaml
    /// </summary>
    public partial class Victory : Window
    {
        public Victory()
        {
            InitializeComponent();
            System.Media.SoundPlayer player = new(@"victory.wav");
            player.Play();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
