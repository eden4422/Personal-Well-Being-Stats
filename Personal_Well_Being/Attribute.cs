using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Personal_Well_Being
{
    internal class Attribute
    {
        private int currentValue;
        private int priority;
        private int totalXP;
        private string name;
        private List<AttributeItem> milestones;
        private List<AttributeItem> tasks;

        internal Attribute(string name, int currentValue, int priority)
        {
            this.name = name;
            this.currentValue = currentValue;
            this.priority = priority;
            this.totalXP = 0;
            this.milestones = new List<AttributeItem>();
            this.tasks = new List<AttributeItem>();
        }

        internal int CurrentValue
        {
            get { return this.currentValue; }
            set { this.currentValue = value; }
        }

        internal int Priority
        { 
            get { return this.priority; }
            set{ this.priority = value; } 
        }

        internal int TotalXP
        {
            get { return this.totalXP; }
            set { this.totalXP = value; }
        }

        internal string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        internal List<AttributeItem> Milestones
        {
            get { return this.milestones;}
        }

        internal List<AttributeItem> Tasks
        {
            get { return this.tasks;}
        }

        internal void AddMilestone(string description, int xpValue)
        {
            Milestone newMilestone = new Milestone(description, xpValue, ref this.milestones);
            newMilestone.OnPropertyChange += this.OwnedItemPropertyChanged;
            this.milestones.Add(newMilestone);
        }

        internal void AddTask(string description, int xpValue)
        {
            Task newTask = new Task(description, xpValue, ref this.tasks);
            newTask.OnPropertyChange += this.OwnedItemPropertyChanged;
            this.tasks.Add(newTask);
        }

        internal void OwnedItemPropertyChanged(Object sender, )
        {

        }
    }
}
