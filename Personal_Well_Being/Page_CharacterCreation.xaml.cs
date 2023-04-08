using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Personal_Well_Being
{
    /// <summary>
    /// Interaction logic for Page_CharacterCreation.xaml
    /// </summary>
    public partial class Page_CharacterCreation : Page
    {
        private MainWindow mainWindow;

        public Page_CharacterCreation(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
        }

        private void UploadPictureButton_Click(object sender, RoutedEventArgs e)
        {
            // We dont need this right now since it is very much using the current uploaded picture.
            //Window_UploadPicture window = new Window_UploadPicture();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";

            if (openFileDialog.ShowDialog() == true)
            {
                string fileName = openFileDialog.FileName;
                this.ImageDisplay.Source = new BitmapImage(new Uri(fileName));
            }
        }

        private void WriteBiographyButton_Click(object sender, RoutedEventArgs e)
        {
            Window_WriteBiography window = new Window_WriteBiography();
            if(window.ShowDialog() == true )
            {

            }
        }

        private void ChooseStatsButton_Click(object sender, RoutedEventArgs e)
        {
            Window_ChooseStats window = new Window_ChooseStats();
            if(window.ShowDialog() == true )
            {

            }
        }

        private void DefineStatsButton_Click(object sender, RoutedEventArgs e)
        {
            Window_DefineStats window = new Window_DefineStats();
            if (window.ShowDialog() == true )
            {

            }
        }

        private void ChooseSkillsButton_Click(object sender, RoutedEventArgs e)
        {
            Window_ChooseSkills window = new Window_ChooseSkills();
            if (window.ShowDialog() == true )
            {

            }
        }

        private void DefineSkillsButton_Click(object sender, RoutedEventArgs e)
        {
            Window_DefineSkills window = new Window_DefineSkills();
            if (window.ShowDialog() == true )
            {

            }
        }

        private void NameButton_Click(object sender, RoutedEventArgs e)
        {
            Window_Name window = new Window_Name();
            if (window.ShowDialog() == true )
            {

            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.mainWindow.ChangePage(new Page_LandingPage(this.mainWindow));
        }

        private void DoneButton_Click(object sender, RoutedEventArgs e)
        {
            UserController UC = new();
            UC.CreateUser("testname");
            UC.CurrentUser.AddStatToSheet("Mood", 1, 2);
            UC.CurrentUser.AddStatToSheet("Fitness", 2, 4);
            UC.CurrentUser.AddStatToSheet("Career", 3, 6);
            UC.CurrentUser.AddStatToSheet("Friends", 4, 6);
            UC.CurrentUser.AddStatToSheet("Romance", 5, 6);
            UC.CurrentUser.AddStatToSheet("Spirituality", 6, 6);
            UC.CurrentUser.AddStatToSheet("School", 7, 6);
            UC.CurrentUser.AddStatToSheet("Family", 8, 6);
            this.mainWindow.ChangePage(new Page_QuestBook(this.mainWindow, UC));
        }
    }
}
