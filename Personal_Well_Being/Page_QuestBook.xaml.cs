using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace Personal_Well_Being
{
    /// <summary>
    /// Interaction logic for Page_QuestBook.xaml
    /// </summary>
    public partial class Page_QuestBook : Page
    {
        private MainWindow mainWindow;

        private UserController UC;

        private ObservableCollection<Attribute> Stats { get; set; }
        private ObservableCollection<Attribute> Skills { get; set; }

        private Attribute? SelectedStatSkill { get; set; }

        private Milestone? SelectedMilestone { get; set; }

        private Task? SelectedTask { get; set; }

        public Page_QuestBook(MainWindow mainWindow, UserController UC)
        {
            InitializeComponent();
            this.UC = UC;
            this.mainWindow = mainWindow;
            this.Stats = UC.CurrentUser.CurrentSheet.Stats;
            this.Skills = UC.CurrentUser.CurrentSheet.Skills;
            this.StatList.ItemsSource = this.Stats;
            this.SkillList.ItemsSource = this.Skills;

            // AddMilestone button becomes enabled when a stat or skill is selected
            this.AddMilestoneButton.IsEnabled = false;

            // AddTask button becomes enabled when a milestone is selected.
            this.AddTaskButton.IsEnabled = false;

            this.CompleteMilestoneButton.IsEnabled = false;
        }

        private void AddMilestoneButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            string milestoneDescription;

            Window_AddMilestone window = new Window_AddMilestone();
            if (window.ShowDialog() == true)
            {
                milestoneDescription = window.mileStoneDescription;

                this.SelectedStatSkill.AddMilestone(milestoneDescription, 50);
                this.MilestoneList.ItemsSource = this.SelectedStatSkill.CurrentMilestones;
            }
        }

        private void AddTaskButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            List<string> tasks = new List<string>();

            Window_AddTask window = new Window_AddTask();
            if (window.ShowDialog() == true)
            {
                tasks = window.tasks;

                foreach (string task in tasks)
                {
                    TaskList.Items.Add(task);
                }

                // connect to backend here.
            }
        }

        private void GearButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Window_Menu window = new Window_Menu(mainWindow);
            window.Show();
        }

        private void ProgressReport_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Window_ProgressReport window = new Window_ProgressReport(this.UC);
            window.Show();
        }

        private void StatList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.SelectedStatSkill = (Attribute?)this.StatList.SelectedItem;
            if (this.SelectedStatSkill != null)
            {
                this.AddMilestoneButton.IsEnabled = true;
                this.AddTaskButton.IsEnabled = true;
                this.MilestoneList.ItemsSource = this.SelectedStatSkill.CurrentMilestones;
            }
            else
            {
                this.AddMilestoneButton.IsEnabled = false;
                this.AddTaskButton.IsEnabled = false;
                this.MilestoneList.ItemsSource = null;
            }
        }

        private void CompleteMilestoneButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (this.MilestoneList.SelectedItem != null)
            {
                ((Milestone)this.MilestoneList.SelectedItem).Complete();
                this.MilestoneList.ItemsSource = this.SelectedStatSkill.CurrentMilestones;
                Victory victory = new Victory();
                victory.Show();
            }
        }

        private void milestoneListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.SelectedMilestone = (Milestone?)this.MilestoneList.SelectedItem;
            if (this.SelectedMilestone != null && !this.SelectedMilestone.IsCompleted)
            {
                this.CompleteMilestoneButton.IsEnabled = true;
            }
            else
            {
                this.CompleteMilestoneButton.IsEnabled = false;
            }
        }

        private void TaskList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.SelectedTask = (Task?)this.TaskList.SelectedItem;
            if (this.SelectedTask != null)
            {
                this.CompleteMilestoneButton.IsEnabled = true;
            }
            else
            {
                this.CompleteMilestoneButton.IsEnabled = false;
            }
        }

        private void SkillList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.SelectedStatSkill = (Attribute?)this.SkillList.SelectedItem;
            if (this.SelectedStatSkill != null)
            {
                this.AddMilestoneButton.IsEnabled = true;
                this.AddTaskButton.IsEnabled = true;
                this.MilestoneList.ItemsSource = this.SelectedStatSkill.CurrentMilestones;
            }
            else
            {
                this.AddMilestoneButton.IsEnabled = false;
                this.AddTaskButton.IsEnabled = false;
                this.MilestoneList.ItemsSource = null;
            }
        }
    }
}
