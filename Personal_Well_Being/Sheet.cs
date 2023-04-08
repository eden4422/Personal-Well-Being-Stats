namespace Personal_Well_Being
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;

    /// <summary>
    /// Creates a sheet object to keep track of stats and skill
    /// </summary>
    internal class Sheet
    {
        private string bio;
        private int totalLevel;
        private int totalXP;
        private List<Attribute> stats;
        private List<Attribute> skills;

        /// <summary>
        /// Initializes a new instance of the <see cref="Sheet"/> class.
        /// </summary>
        public Sheet() 
        { 
            bio = string.Empty;
            totalLevel = 0;
            totalXP = 0;
            stats = new List<Attribute> ();
            skills = new List<Attribute> ();
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
        public List<Attribute> Stats
        {
            get
            {
                return this.stats;
            }
        }

        /// <summary>
        /// Gets list of skills.
        /// </summary>
        public List<Attribute> Skills
        {
            get
            {
                return this.skills;
            }
        }

        public ObservableCollection<AttributeItem> TodoItems
        {
            get
            {
                var allAttributes = this.Stats.Concat(this.Skills);
                ObservableCollection<AttributeItem> collection = new ObservableCollection<AttributeItem>();
                foreach (Attribute attribute in allAttributes)
                {
                    collection.Concat(attribute.UncompletedAttributeItems);
                }
                IEnumerable<AttributeItem> todoMilestones = from attributeitem in collection orderby attributeitem.Priority descending select attributeitem;
                //return completedMilestones.ToList();
                return new ObservableCollection<AttributeItem>(todoMilestones.ToList());
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

            foreach (Attribute stat in stats)
            {
                this.totalXP += stat.TotalXP;
            }

            foreach (Attribute skill in skills)
            {
                this.totalXP += skill.TotalXP;
            }

        }

        /// <summary>
        /// Adds a new stat attribute to the list of stats.
        /// </summary>
        /// <param name="newStat">The new stat to be added.</param>
        public void AddStat(string statName, int initialLevel, int priority)
        {
            Attribute newStat = new Attribute(statName, initialLevel);
            this.stats.Add(newStat);
            newStat.PropertyChanged += this.AttributeXpChange;
        }

        /// <summary>
        /// Adds a new skill attribute to the list of stats.
        /// </summary>
        /// <param name="newSkill">The new skill to be added.</param>
        public void AddSkill(string statName, int initialLevel, int priority)
        {
            Attribute newSkill = new Attribute(statName, initialLevel);
            this.skills.Add(newSkill);
            newSkill.PropertyChanged += this.AttributeXpChange;
        }
    }
}
