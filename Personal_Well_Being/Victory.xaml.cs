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
    /// Interaction logic for Victory.xaml
    /// </summary>
    public partial class Victory : Window
    {
        public Victory()
        {
            InitializeComponent();
            System.Media.SoundPlayer player = new System.Media.SoundPlayer();
            player.SoundLocation = "D:\\Git\\Personal-Well-Being-Stats\\Personal_Well_Being\\victory.wav";
            player.Load();
            player.Play();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
