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

        public Page_QuestBook(MainWindow mainWindow, UserController UC)
        {
            InitializeComponent();
            this.UC = UC;
            this.mainWindow = mainWindow;
            this.UserName.Content = UC.CurrentUser.Name;
            this.Stats = UC.CurrentUser.CurrentSheet.Stats;
            this.StatList.ItemsSource = this.Stats;
        }
    }
}
