using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Personal_Well_Being
{
    /// <summary>
    /// Interaction logic for Window_AddTask.xaml
    /// </summary>
    public partial class Window_AddTask : Window
    {
        public List<string> tasks;

        public Window_AddTask()
        {
            InitializeComponent();

            tasks = new List<string>();
        }

        private void AddTasksButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (string item in listView.Items)
            {
                tasks.Add(item);
            }

            DialogResult = true;

            this.Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            listView.Items.Add(this.taskBox.Text);
        }
    }
}
