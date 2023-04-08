namespace Personal_Well_Being
{
    internal class User
    {
        // Profile picture

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
        }
    }
}
