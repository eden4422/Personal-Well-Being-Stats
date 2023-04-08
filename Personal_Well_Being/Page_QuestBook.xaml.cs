using System;
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
            try
            {
                this.UserName.Content = UC.CurrentUser.Name;
            }
            catch(ArgumentNullException e)
            {
                this.UserName.Content = "N/A";
            }
            this.Stats = UC.CurrentUser.CurrentSheet.Stats;
            this.Skills = UC.CurrentUser.CurrentSheet.Skills;
            this.StatList.ItemsSource = this.Stats;
            this.SkilList.ItemsSource = this.Skills;
        }
    }
}
