using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_Well_Being
{
    internal class User
    {
        private Report userReport;
        private string userName;
        private Sheet startingSheet;
        private Sheet currentSheet;
        private Sheet goalSheet;
        // Profile picture

        internal Report UserReport
        {
            get {  return userReport; }
        }

        internal string Name
        {
            get { return userName; }
        }
        internal Sheet StartingSheet
        {
            get { return this.startingSheet; }
        }

        internal Sheet CurrentSheet
        {
            get { return this.CurrentSheet; }
        }

        internal Sheet GoalSheet
        {
            get { return this.GoalSheet; }
        }


        /// <summary>
        /// Generates a new instance of the user class.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        internal User(string userName)
        {
            this.userName = userName;
            this.startingSheet = new Sheet();
            this.goalSheet = new Sheet();
            this.currentSheet = new Sheet();
        }

        /// <summary>
        /// Adds a stat attribute to all three sheets.
        /// </summary>
        /// <param name="statName">Name of the new stat</param>
        /// <param name="initialLevel">The intitial level of the new stat</param>
        /// <param name="priority">The priority level of the stat</param>
        internal void AddStatToSheets(string statName, int initialLevel, int priority)
        {
            this.startingSheet.AddStat(statName, initialLevel, priority);
            this.goalSheet.AddStat(statName, initialLevel, priority);
            this.currentSheet.AddStat(statName, initialLevel, priority);
        }

        /// <summary>
        /// Adds a skill attribute to all three sheets
        /// </summary>
        /// <param name="statName">Name of the new skill</param>
        /// <param name="initialLevel">The initial level of the new skill</param>
        /// <param name="priority">The priority level of the skill</param>
        internal void AddSkillToSheets(string statName, int initialLevel, int priority)
        {
            this.startingSheet.AddSkill(statName, initialLevel, priority);
            this.goalSheet.AddSkill(statName, initialLevel, priority);
            this.currentSheet.AddSkill(statName, initialLevel, priority);
        }

        internal void GenerateReport()
        {
            this.userReport.Update(this.startingSheet, this.currentSheet, this.goalSheet);
        }
    }
}
