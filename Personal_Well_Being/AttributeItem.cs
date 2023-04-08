// Author: Rick Roslof

using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Personal_Well_Being
{
    /// <summary>
    /// Abstract class for shared Task and Milestone features.
    /// </summary>
    internal abstract class AttributeItem : INotifyAttributeItemPropertyChanged
    {
        private string description;

        private int xpValue;

        /// <summary>
        /// Item description.
        /// </summary>
        public string Description
        {
            get { return description; }
            set
            {
                if (this.description != value)
                {
                    description = value;
                    OnPropertyChanged(nameof(Description));
                }
            }
        }

        /// <summary>
        /// XP value returned on completion.
        /// </summary>
        public int XpValue
        {
            get { return xpValue; }
            set
            {
                if (this.xpValue != value)
                {
                    xpValue = value;
                    OnPropertyChanged(nameof(XpValue));
                }
            }
        }

        /// <summary>
        /// Reference to parent list.
        /// </summary>
        public ObservableCollection<AttributeItem> parent;

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
        public AttributeItem(string description, int xpValue, ObservableCollection<AttributeItem> parent)
        {
            this.Description = description;
            this.XpValue = xpValue;
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
            this.AttributeItemPropertyChanged?.Invoke(this, new AttributeItemPropertyChangedEventArgs(propertyName, this.XpValue));
        }

    }
}
