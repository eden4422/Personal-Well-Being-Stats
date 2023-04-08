using System.Windows;

namespace Personal_Well_Being
{
    /// <summary>
    /// Interaction logic for Window_ChooseStats.xaml
    /// </summary>
    public partial class Window_ChooseStats : Window
    {
        public bool? mood;
        public bool? fitness;
        public bool? career;
        public bool? friends;
        public bool? companionship;
        public bool? spirituality;
        public bool? school;
        public bool? family;

        public Window_ChooseStats()
        {
            InitializeComponent();
        }

        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            this.mood = MoodBox.IsChecked;
            this.fitness = FitnessBox.IsChecked;
            this.career = CareerBox.IsChecked;
            this.friends = FriendsBox.IsChecked;
            this.companionship = CompanionshipBox.IsChecked;
            this.spirituality = SpiritualityBox.IsChecked;
            this.school = SchoolBox.IsChecked;
            this.family = FamilyBox.IsChecked;

            DialogResult = true;
            this.Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }
    }
}
