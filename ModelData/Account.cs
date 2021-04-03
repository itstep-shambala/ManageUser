namespace ModelData
{
    public class Account
    {
        public int id;
        public string login;
        public string password;
        public bool isBlocked;
        public string role;
        public Account(){}
        public Account(string login, string password)
        {
            this.login = login;
            this.password = password;
        }
    }
}