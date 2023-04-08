namespace Personal_Well_Being
{
    internal class UserController
    {
        User? CurrentUser { get; set; }

        public void CreateUser(string username)
        {
            CurrentUser = new(username);
        }
    }
}
