// Author: Rick Roslof

using System.Collections.Generic;

namespace Personal_Well_Being
{
    /// <summary>
    /// Class for milestone items.
    /// </summary>
    internal class Milestone : AttributeItem
    {
        /// <summary>
        /// Initializes a new instance of Milestone.
        /// </summary>
        /// <param name="description">Description of item.</param>
        /// <param name="xpValue">XP value to return on completion.</param>
        /// <param name="parent">Reference to owner list.</param>
        public Milestone(string description, int xpValue, List<AttributeItem> parent)
            : base(description, xpValue, parent)
        {
            this.IsCompleted = false;
        }

        /// <summary>
        /// Flag for Milestone completion.
        /// </summary>
        public bool IsCompleted { get; private set; }

        /// <summary>
        /// Comlpetes milestone.
        /// </summary>
        public override void Complete()
        {
            this.IsCompleted = true;
            OnPropertyChanged(nameof(IsCompleted));
        }
    }
}
