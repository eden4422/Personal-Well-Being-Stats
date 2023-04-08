
﻿using System.Collections.Generic;
﻿using Microsoft.Win32;
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
            bool? mood = false;
            bool? fitness = false;
            bool? career = false;
            bool? friends = false;
            bool? companionship = false;
            bool? spirituality = false;
            bool? school = false;
            bool? family = false;

            Window_ChooseStats window = new Window_ChooseStats();
            if(window.ShowDialog() == true )
            {
                mood = window.mood;
                fitness = window.fitness;
                career = window.career;
                friends = window.friends;
                companionship = window.companionship;
                spirituality= window.spirituality;
                school = window.school;
                family = window.family;

                // LINK TO BACKEND HERE
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
            List<string> skills = new List<string>();

            Window_ChooseSkills window = new Window_ChooseSkills();
            if (window.ShowDialog() == true )
            {
                // this is a list of strings
                skills = window.skills;

                // LINK TO BACKEND HERE
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
            UC.CurrentUser.CurrentSheet.AddStat("Mood", 1, 2);
            UC.CurrentUser.CurrentSheet.AddStat("Fitness", 2, 4);
            UC.CurrentUser.CurrentSheet.AddStat("Career", 3, 6);
            UC.CurrentUser.CurrentSheet.AddStat("Friends", 4, 6);
            UC.CurrentUser.CurrentSheet.AddStat("Romance", 5, 6);
            UC.CurrentUser.CurrentSheet.AddStat("Spirituality", 6, 6);
            UC.CurrentUser.CurrentSheet.AddStat("School", 7, 6);
            UC.CurrentUser.CurrentSheet.AddStat("Family", 8, 6);
            this.mainWindow.ChangePage(new Page_QuestBook(this.mainWindow, UC));
        }
    }
}
