// Author: Rick Roslof

using System.Collections.Generic;

namespace Personal_Well_Being
{
    /// <summary>
    /// Abstract class for shared Task and Milestone features.
    /// </summary>
    internal abstract class AttributeItem : INotifyAttributeItemPropertyChanged
    {
        /// <summary>
        /// Item description.
        /// </summary>
        public string description;

        /// <summary>
        /// XP value returned on completion.
        /// </summary>
        public int xpValue;

        /// <summary>
        /// Reference to parent list.
        /// </summary>
        public List<AttributeItem> parent;

        /// <summary>
        /// Property changed event.
        /// </summary>
        public event AttributeItemPropertyChangedEventHandler? AttributeItemPropertyChanged;

        /// <summary>
        /// Base constructor for AttributeItem objects.
        /// </summary>
        /// <param name="description">Description of item.</param>
        /// <param name="xpValue">XP value to return on completion.</param>
        /// <param name="parent">Reference to owner list.</param>
        public AttributeItem(string description, int xpValue, List<AttributeItem> parent)
        {
            this.description = description;
            this.xpValue = xpValue;
            this.parent = parent;
        }

        /// <summary>
        /// Abstract function for item completion.
        /// </summary>
        public abstract void Complete();

        /// <summary>
        /// Removes item from owner list.
        /// </summary>
        public void Remove()
        {
            parent.Remove(this);
        }

        /// <summary>
        /// Helper function to allow child classes to call property changed event.
        /// </summary>
        /// <param name="propertyName">Name of property that changed.</param>
        public void OnPropertyChanged(string propertyName)
        {
            this.AttributeItemPropertyChanged?.Invoke(this, new AttributeItemPropertyChangedEventArgs(propertyName, this.xpValue));
        }

    }
}
