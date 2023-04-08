using System.ComponentModel;

namespace Personal_Well_Being
{
    internal class AttributeItemPropertyChangedEventArgs : PropertyChangedEventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref='AttributeItemPropertyChangedEventArgs'/>
        /// class.
        /// </summary>
        public AttributeItemPropertyChangedEventArgs(string? propertyName, int xpValue)
            : base(propertyName)
        {
            XpValue = xpValue;
        }

        /// <summary>
        /// XP value parameter.
        /// </summary>
        int XpValue { get; }
    }
}
