namespace Personal_Well_Being
{
    public class UserController
    {
        internal User? CurrentUser { get; set; }

        public void CreateUser(string username)
        {
            CurrentUser = new(username);
        }
    }
}
