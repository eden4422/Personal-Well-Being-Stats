using System.Collections.Generic;
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

        private List<Attribute> Stats { get; set; }
        private List<Attribute> Skills { get; set; }

        public Page_QuestBook(MainWindow mainWindow, UserController UC)
        {
            InitializeComponent();
            this.UC = UC;
            this.mainWindow = mainWindow;
            this.Stats = UC.CurrentUser.CurrentSheet.Stats;
            this.Skills = UC.CurrentUser.CurrentSheet.Skills;
            this.StatList.ItemsSource = this.Stats;
            this.SkilList.ItemsSource = this.Skills;

            // AddMilestone button becomes enabled when a stat or skill is selected
            this.AddMilestoneButton.IsEnabled = false;

            // AddTask button becomes enabled when a milestone is selected.
            this.AddTaskButton.IsEnabled = false;
        }

        private void AddMilestoneButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            string milestoneDescription;

            Window_AddMilestone window = new Window_AddMilestone();
            if (window.ShowDialog() == true)
            {
                milestoneDescription = window.mileStoneDescription;

                // Connect to Backend here.
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
                    taskListView.Items.Add(task);
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
            Window_ProgressReport window = new Window_ProgressReport();
            window.Show();
        }

        private void CompletedButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Victory victory = new Victory();
            victory.Show();
        }
    }
}
