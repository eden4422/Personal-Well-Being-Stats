// Author: Rick Roslof

using System.Collections.Generic;
using System.ComponentModel;

namespace Personal_Well_Being
{
    internal class Report : INotifyPropertyChanged
    {
        /// <summary>
        /// List of stat names, priority, initial values, current values, and goal values.
        /// </summary>
        public List<(string, int, int, int, int)> StatProgress { get; private set; } = new();

        /// <summary>
        /// List of skill names, priority, initial values, current values, and goal values.
        /// </summary>
        public List<(string, int, int, int, int)> SkillProgress { get; private set; } = new();

        /// <summary>
        /// Property changed event.
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Updates stat and skill progress properties.
        /// </summary>
        /// <param name="sheet">Current skill sheet.</param>
        public void Update(Sheet sheet)
        {
            // Update stats
            this.StatProgress = new();
            List<Attribute> stats = sheet.Stats;

            foreach (Attribute attribute in stats)
            {
                this.StatProgress.Add((attribute.Name, attribute.Priority, attribute.InitialValue, attribute.InitialValue + attribute.CompletedMilestones.Count, attribute.InitialValue + attribute.Milestones.Count));
            }

            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(StatProgress)));


            // Update skills
            this.SkillProgress = new();
            List<Attribute> skills = sheet.Skills;

            foreach (Attribute attribute in skills)
            {
                this.StatProgress.Add((attribute.Name, attribute.Priority, attribute.InitialValue, attribute.InitialValue + attribute.CompletedMilestones.Count, attribute.InitialValue + attribute.Milestones.Count));
            }

            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SkillProgress)));
        }
    }
}
