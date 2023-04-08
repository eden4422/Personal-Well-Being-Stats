using System.Collections.ObjectModel;
using System.Windows;

namespace Personal_Well_Being
{
    /// <summary>
    /// Interaction logic for Window_ProgressReport.xaml
    /// </summary>
    public partial class Window_ProgressReport : Window
    {
  
        private UserController UC;

        private ObservableCollection<Milestone> milestoneList = new();

        public Window_ProgressReport( UserController UC)
        {
            InitializeComponent();
            this.UC = UC;
            foreach (Attribute att in UC.CurrentUser.CurrentSheet.Stats)
            {
                foreach (Milestone ms in att.CurrentMilestones)
                {
                    milestoneList.Add(ms);
                }
            }

            foreach (Attribute att in UC.CurrentUser.CurrentSheet.Skills)
            {
                foreach (Milestone ms in att.CurrentMilestones)
                {
                    milestoneList.Add(ms);
                }
            }
            this.ObjectiveList.ItemsSource = milestoneList;
        }
    }
}
