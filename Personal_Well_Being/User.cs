namespace Personal_Well_Being
{
    internal class User
    {
        // Profile picture

        internal Report UserReport { get; }

        internal string Name { get; }

        internal Sheet CurrentSheet { get; }


        /// <summary>
        /// Generates a new instance of the user class.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        internal User(string userName)
        {
            this.Name = userName;
            this.CurrentSheet = new();
            this.UserReport = new();
        }

        /// <summary>
        /// Adds a stat attribute to all three sheets.
        /// </summary>
        /// <param name="statName">Name of the new stat</param>
        /// <param name="initialLevel">The intitial level of the new stat</param>
        /// <param name="priority">The priority level of the stat</param>
        internal void AddStatToSheet(string statName, int initialLevel, int priority)
        {
            this.CurrentSheet.AddStat(statName, initialLevel, priority);
        }

        /// <summary>
        /// Adds a skill attribute to all three sheets
        /// </summary>
        /// <param name="statName">Name of the new skill</param>
        /// <param name="initialLevel">The initial level of the new skill</param>
        /// <param name="priority">The priority level of the skill</param>
        internal void AddSkillToSheet(string statName, int initialLevel, int priority)
        {
            this.CurrentSheet.AddSkill(statName, initialLevel, priority);
        }

        internal void GenerateReport()
        {
            this.UserReport.Update(this.CurrentSheet);
        }
    }
}
