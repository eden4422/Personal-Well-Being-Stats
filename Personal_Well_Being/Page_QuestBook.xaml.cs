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
            
            // commented out bc everything is null
            /*
            this.UserName.Content = UC.CurrentUser.Name;
            this.Stats = UC.CurrentUser.CurrentSheet.Stats;
            this.Skills = UC.CurrentUser.CurrentSheet.Skills;
            this.StatList.ItemsSource = this.Stats;
            this.SkilList.ItemsSource = this.Skills;
             */
        }

        private void AddMilestoneButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void AddTaskButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {

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

        }
    }
}
