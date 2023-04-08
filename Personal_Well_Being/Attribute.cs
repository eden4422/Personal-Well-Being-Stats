using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace Personal_Well_Being
{
    internal class Attribute : INotifyPropertyChanged
    {
        private int totalXP;

        /// <summary>
        /// Creates a new instance of the Attribute class.
        /// </summary>
        /// <param name="name">Name of the attribute</param>
        /// <param name="currentValue">The starting/current value of the attribute.</param>
        /// <param name="priority">The priority of the attribute.</param>
        internal Attribute(string name, int currentValue)
        {
            this.Name = name;
            this.InitialValue = currentValue;
            this.totalXP = 0;
            this.Milestones = new ObservableCollection<AttributeItem>();
            this.Tasks = new ObservableCollection<AttributeItem>();
        }

        public int InitialValue { get; set; }

        public int CurrentValue
        {
            get
            {
                return this.InitialValue + this.CompletedMilestones.Count;
            }
        }

        public int GoalValue
        {
            get
            {
                return this.InitialValue + this.Milestones.Count;
            }
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

        public string Name { get; set; }

        public ObservableCollection<AttributeItem> UncompletedAttributeItems
        {
            get
            {
                return new ObservableCollection<AttributeItem>(this.CompletedMilestones.Union(Tasks).ToList());
            }
        }

        internal ObservableCollection<AttributeItem> Milestones { get; }

        internal ObservableCollection<AttributeItem> CompletedMilestones
        {
            get
            {
                IEnumerable<AttributeItem> completedMilestones = from Milestone milestone in this.Milestones where milestone.IsCompleted == true select milestone;
                //return completedMilestones.ToList();
                return new ObservableCollection<AttributeItem>(completedMilestones.ToList());
            }
        }

        internal ObservableCollection<AttributeItem> Tasks { get; }

        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Instantiates a new milestone object, adds it to this attribute's list of milestones. 
        /// Also, subscribes this OwnedItemPropertyChanged to the OnPropertyChange event of the new milestone.
        /// </summary>
        /// <param name="description"></param>
        /// <param name="xpValue"></param>
        internal void AddMilestone(string description, int xpValue)
        {
            Milestone newMilestone = new Milestone(description, xpValue, this.Milestones);
            newMilestone.AttributeItemPropertyChanged += this.OwnedItemPropertyChanged;
            this.Milestones.Add(newMilestone);
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
            Task newTask = new Task(description, xpValue, this.Tasks, frequency);
            newTask.AttributeItemPropertyChanged += this.OwnedItemPropertyChanged;
            this.Tasks.Add(newTask);
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
