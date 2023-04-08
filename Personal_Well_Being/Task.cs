// Author: Rick Roslof

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Personal_Well_Being
{
    /// <summary>
    /// Class for task items.
    /// </summary>
    internal class Task : AttributeItem
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="description">Description of item.</param>
        /// <param name="xpValue">XP value to return on completion.</param>
        /// <param name="parent">Reference to owner list.</param>
        /// <param name="frequency">Frequency of task recurrance.</param>
        public Task(string description, int xpValue, ObservableCollection<AttributeItem> parent, TimeSpan frequency)
            : base(description, xpValue, parent)
        {
            this.TimesCompleted = 0;
            this.Frequency = frequency;
        }

        /// <summary>
        /// Frequency of task.
        /// </summary>
        public TimeSpan Frequency { get; set; }

        /// <summary>
        /// Number of times completed.
        /// </summary>
        public int TimesCompleted { get; private set; }

        /// <summary>
        /// Completes task.
        /// </summary>
        public override void Complete()
        {
            this.TimesCompleted++;
            OnPropertyChanged(nameof(TimesCompleted));
        }
    }
}
