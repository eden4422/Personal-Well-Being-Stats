
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
        private UserController UC;

        public Page_CharacterCreation(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;

            UploadPictureButton.IsEnabled = false;
            WriteBiographyButton.IsEnabled = false;
            ChooseStatsButton.IsEnabled = false;
            ChooseSkillsButton.IsEnabled = false;

            DoneButton.IsEnabled = false;

            this.UC = new UserController();
        }

        private void NameButton_Click(object sender, RoutedEventArgs e)
        {
            Window_Name window = new Window_Name();
            if (window.ShowDialog() == true)
            {
                this.UC.CreateUser(window.InputName);

                NameButton.IsEnabled = false;
                UploadPictureButton.IsEnabled = true;

                this.listView.Items.Add("Name: " + window.InputName);
            }
        }

        private void UploadPictureButton_Click(object sender, RoutedEventArgs e)
        {
            // We dont need this right now since it is very much using the current uploaded picture.
            //Window_UploadPicture window = new Window_UploadPicture();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";
            openFileDialog.InitialDirectory = System.IO.Path.Combine(Environment.CurrentDirectory, @"Default Images");


            if (openFileDialog.ShowDialog() == true)
            {
                string fileName = openFileDialog.FileName;
                this.ImageDisplay.Source = new BitmapImage(new Uri(fileName));

                UploadPictureButton.IsEnabled = false;
                WriteBiographyButton.IsEnabled= true;
            }
        }

        private void WriteBiographyButton_Click(object sender, RoutedEventArgs e)
        {
            Window_WriteBiography window = new Window_WriteBiography();
            if(window.ShowDialog() == true )
            {

                WriteBiographyButton.IsEnabled = false;
                ChooseStatsButton.IsEnabled = true;

                listView.Items.Add("Biography: " + window.bio);
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

            // please maybechange the nullability of these bools? 
            // also, for now we are initiating everything at priority and starting level 0, perhaps within the window we additionally,
            // if something is selected, initialize those starting parameters
            Window_ChooseStats window = new Window_ChooseStats();
            if(window.ShowDialog() == true )
            {
                mood = window.mood;
                if(mood != null)
                {
                    if ((bool)mood)
                    {
                        if(UC.CurrentUser != null)
                        {
                            UC.CurrentUser.CurrentSheet.AddStat("Mood", 0, 0);
                        }
                    }
                }
                fitness = window.fitness;
                if (fitness != null)
                {
                    if ((bool)fitness)
                    {
                        if (UC.CurrentUser != null)
                        {
                            UC.CurrentUser.CurrentSheet.AddStat("Fitness", 0, 0);
                        }
                    }
                }
                career = window.career;
                if (career != null)
                {
                    if ((bool)career)
                    {
                        if (UC.CurrentUser != null)
                        {
                            UC.CurrentUser.CurrentSheet.AddStat("Career", 0, 0);
                        }
                    }
                }
                friends = window.friends;
                if (friends != null)
                {
                    if ((bool)friends)
                    {
                        if (UC.CurrentUser != null)
                        {
                            UC.CurrentUser.CurrentSheet.AddStat("Social", 0, 0);
                        }
                    }
                }
                companionship = window.companionship;
                if (companionship != null) // maybe change var name here
                {
                    if ((bool)companionship)
                    {
                        if (UC.CurrentUser != null)
                        {
                            UC.CurrentUser.CurrentSheet.AddStat("Romance", 0, 0);
                        }
                    }
                }
                spirituality = window.spirituality;
                if (spirituality != null) 
                {
                    if ((bool)spirituality)
                    {
                        if (UC.CurrentUser != null)
                        {
                            UC.CurrentUser.CurrentSheet.AddStat("Spirituality", 0, 0);
                        }
                    }
                }

                school = window.school;
                if (school != null) 
                {
                    if ((bool)school)
                    {
                        if (UC.CurrentUser != null)
                        {
                            UC.CurrentUser.CurrentSheet.AddStat("Knowledge", 0, 0);
                        }
                    }

                }
                family = window.family;
                if (family != null) 
                {
                    if ((bool)family)
                    {
                        if (UC.CurrentUser != null)
                        {
                            UC.CurrentUser.CurrentSheet.AddStat("Financial", 0, 0);
                        }
                    }

                }

                ChooseStatsButton.IsEnabled = false;
                ChooseSkillsButton.IsEnabled = true;

                listView.Items.Add("Stats:");
                foreach (Attribute attribute in UC.CurrentUser.CurrentSheet.Stats)
                {
                    listView.Items.Add("--->" + attribute.Name);
                }
            }
        }

        private void ChooseSkillsButton_Click(object sender, RoutedEventArgs e)
        {
            List<string> skills = new List<string>();

            Window_ChooseSkills window = new Window_ChooseSkills();
            if (window.ShowDialog() == true )
            {
                // this is a list of strings
                if (UC.CurrentUser != null)
                {
                    foreach (string skill in window.skills)
                    {
                        UC.CurrentUser.CurrentSheet.AddSkill(skill, 0, 0);
                    }
                }

                ChooseSkillsButton.IsEnabled = false;
                DoneButton.IsEnabled = true;

                listView.Items.Add("Skills:");
                foreach(string skill in window.skills)
                {
                    listView.Items.Add("--->" + skill);
                }
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.mainWindow.ChangePage(new Page_LandingPage(this.mainWindow));
        }

        private void DoneButton_Click(object sender, RoutedEventArgs e)
        {
            this.mainWindow.ChangePage(new Page_QuestBook(this.mainWindow, this.UC));
        }
    }
}
