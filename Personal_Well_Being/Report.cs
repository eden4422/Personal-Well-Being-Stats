using System.Collections.Generic;
using System.ComponentModel;

namespace Personal_Well_Being
{
    internal class Report : INotifyPropertyChanged
    {
        /// <summary>
        /// List of stat names, initial values, current values, and goal values.
        /// </summary>
        public List<(string, int, int, int)> StatProgress { get; private set; } = new();

        /// <summary>
        /// List of skill names, initial values, current values, and goal values.
        /// </summary>
        public List<(string, int, int, int)> SkillProgress { get; private set; } = new();

        /// <summary>
        /// Property changed event.
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Updates stat and skill progress properties.
        /// </summary>
        /// <param name="initial">Initial skill sheet.</param>
        /// <param name="current">Current skill sheet.</param>
        /// <param name="goal">Goal skill sheet.</param>
        public void Update(Sheet initial, Sheet current, Sheet goal)
        {
            // Update stats
            this.StatProgress = new();
            List<Attribute> initialStats = initial.Stats;
            List<Attribute> currentStats = current.Stats;
            List<Attribute> goalStats = goal.Stats;

            for (int i = 0; i < initialStats.Count; i++)
            {
                this.StatProgress.Add((initialStats[i].Name, initialStats[i].CurrentValue, currentStats[i].CurrentValue, goalStats[i].CurrentValue));
            }

            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(StatProgress)));


            // Update skills
            this.SkillProgress = new();
            List<Attribute> initialSkills = initial.Skills;
            List<Attribute> currentSkills = current.Skills;
            List<Attribute> goalSkills = goal.Skills;

            for (int i = 0; i < initialStats.Count; i++)
            {
                this.StatProgress.Add((initialSkills[i].Name, initialSkills[i].CurrentValue, currentSkills[i].CurrentValue, goalSkills[i].CurrentValue));
            }

            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SkillProgress)));
        }
    }
}
