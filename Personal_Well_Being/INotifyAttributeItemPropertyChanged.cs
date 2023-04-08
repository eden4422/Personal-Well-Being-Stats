namespace Personal_Well_Being
{
    internal interface INotifyAttributeItemPropertyChanged
    {
        /// <summary>
        /// Occurs when an AttributeItem property changes.
        /// </summary>
        event AttributeItemPropertyChangedEventHandler? AttributeItemPropertyChanged;
    }
}
