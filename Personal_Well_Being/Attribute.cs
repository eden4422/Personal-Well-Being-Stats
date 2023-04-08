using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Personal_Well_Being
{
    internal class Attribute : INotifyPropertyChanged
    {
        private int currentValue;
        private int priority;
        private int totalXP;
        private string name;
        private List<AttributeItem> milestones;
        private List<AttributeItem> tasks;

        /// <summary>
        /// Creates a new instance of the Attribute class.
        /// </summary>
        /// <param name="name">Name of the attribute</param>
        /// <param name="currentValue">The starting/current value of the attribute.</param>
        /// <param name="priority">The priority of the attribute.</param>
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
            set 
            { 
                if (this.totalXP != value)
                {
                    this.totalXP = value;
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("XP")); 
                }
                
                    
            }
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

        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Instantiates a new milestone object, adds it to this attribute's list of milestones. 
        /// Also, subscribes this OwnedItemPropertyChanged to the OnPropertyChange event of the new milestone.
        /// </summary>
        /// <param name="description"></param>
        /// <param name="xpValue"></param>
        internal void AddMilestone(string description, int xpValue)
        {
            Milestone newMilestone = new Milestone(description, xpValue, this.milestones);
            newMilestone.AttributeItemPropertyChanged += this.OwnedItemPropertyChanged;
            this.milestones.Add(newMilestone);
        }

        /// <summary>
        /// Instantiates a new task and adds it to this attribute's list of tasks. Additionally, subscribes this OwnedItemPropertyChanged method
        /// to the OnPropertyChange event of the task created.
        /// </summary>
        /// <param name="description">The description of the task to be created.</param>
        /// <param name="xpValue">The xp value of the task.</param>
        /// <param name="frequency">The frequency of the task.</param>
        internal void AddTask(string description, int xpValue, TimeSpan frequency)
        {
            Task newTask = new Task(description, xpValue, this.tasks, frequency);
            newTask.AttributeItemPropertyChanged += this.OwnedItemPropertyChanged;
            this.tasks.Add(newTask);
        }

        internal void OwnedItemPropertyChanged(Object sender, AttributeItemPropertyChangedEventArgs e)
        {
            if (e.PropertyName == "IsCompleted")
            {
                this.TotalXP += e.XpValue;
            }
        }
    }
}
