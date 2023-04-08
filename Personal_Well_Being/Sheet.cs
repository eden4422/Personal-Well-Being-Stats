﻿namespace Personal_Well_Being
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    /// <summary>
    /// Creates a sheet object to keep track of stats and skill
    /// </summary>
    internal class Sheet
    {
        private string bio;
        private int totalLevel;
        private int totalXP;
        private List<AttributesItem> stats;
        private List<AttributesItem> skills;

        /// <summary>
        /// Initializes a new instance of the <see cref="Sheet"/> class.
        /// </summary>
        public Sheet() 
        { 
            bio = string.Empty;
            totalLevel = 0;
            totalXP = 0;
            stats = new List<AttributeItem> ();
            skills = new List<AttributeItem> ();
        }

        /// <summary>
        /// Gets Bio.
        /// </summary>
        public string Bio
        {
            get
            {
                return this.bio;
            }
            set
            {
                this.bio = value;
            }
        }

        /// <summary>
        /// Gets total level.
        /// </summary>
        public int TotalLevel
        {
            get
            {
                return this.totalLevel;
            }
        }

        /// <summary>
        /// Gets total xp.
        /// </summary>
        public int TotalXP
        {
            get
            {
                return this.totalXP;
            }
        }

        /// <summary>
        /// Gets list of stats.
        /// </summary>
        public List<AttributesItem> Stats
        {
            get
            {
                return this.stats;
            }
        }

        /// <summary>
        /// Gets list of skills.
        /// </summary>
        public List<AttributesItem> Skills
        {
            get
            {
                return this.skills;
            }
        }

        /// <summary>
        /// Updates the total xp value if an attribute item xp is updated.
        /// </summary>
        /// <param name="sender">Attribute that changed.</param>
        /// <param name="e">Type of change.</param>
        public void AttributeXpChange(object? sender, PropertyChangedEventArgs e)
        {
            this.totalXP = 0;

            foreach (AttributeItem stat in stats)
            {
                this.totalXP += stat.TotalXP;
            }

            foreach (AttributeItem skill in skills)
            {
                this.totalXP += skill.TotalXP;
            }

        }

        /// <summary>
        /// Adds a new stat attribute to the list of stats.
        /// </summary>
        /// <param name="newStat">The new stat to be added.</param>
        public void AddStat(AttributeItem newStat)
        {
            this.stats.Add(newStat);
            newStat.XPChanged += this.AttributeXpChange;
        }

        /// <summary>
        /// Adds a new skill attribute to the list of stats.
        /// </summary>
        /// <param name="newSkill">The new skill to be added.</param>
        public void AddSkill(AttributeItem newSkill)
        {
            this.skills.Add(newSkill);
            newSkill.XPChanged += this.AttributeXpChange;
        }
    }
}