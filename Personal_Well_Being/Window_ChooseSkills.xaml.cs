using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace Personal_Well_Being
{
    /// <summary>
    /// Interaction logic for Window_ChooseSkills.xaml
    /// </summary>
    public partial class Window_ChooseSkills : Window
    {
        public List<string> skills;

        public Window_ChooseSkills()
        {
            InitializeComponent();
            skills = new List<string>();
        }

        private void AcceptButton_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)Painting.IsChecked) { skills.Add("Painting"); }
            if ((bool)Writing.IsChecked) { skills.Add("Writing"); }
            if ((bool)Storytelling.IsChecked) { skills.Add("Storytelling"); }
            if ((bool)Dancing.IsChecked) { skills.Add("Dancing"); }
            if ((bool)Dressmaking.IsChecked) { skills.Add("Dressmaking"); }
            if ((bool)Blacksmithing.IsChecked) { skills.Add("Blacksmithing"); }
            if ((bool)Graphic.IsChecked) { skills.Add("Graphic Design"); }
            if ((bool)Acting.IsChecked) { skills.Add("Acting"); }
            if ((bool)Knitting.IsChecked) { skills.Add("Knitting"); }
            if ((bool)JewelryMaking.IsChecked) { skills.Add("Jewelry-Making"); }
            if ((bool)LeatherWorking.IsChecked) { skills.Add("Leather-Working"); }
            if ((bool)Pottery.IsChecked) { skills.Add("Pottery"); }
            if ((bool)Hairstyling.IsChecked) { skills.Add("Hairstyling"); }
            if ((bool)Origami.IsChecked) { skills.Add("Origami"); }
            if ((bool)Calligraphy.IsChecked) { skills.Add("Calligraphy"); }

            foreach (ListViewItem item in listView.Items) 
            { 
                skills.Add((string)item.Content);
            }

            DialogResult = true;
            this.Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddSkill_Button(object sender, RoutedEventArgs e)
        {
            ListViewItem listViewItem = new ListViewItem();
            listViewItem.Content = SkillInput.Text;
            if ((string)listViewItem.Content != string.Empty)
            {
                listView.Items.Add(listViewItem);
            }
            SkillInput.Text = "";
        }
    }
}
