namespace ModelData
{
    public class User
    {
        public int id;
        public string firstName;
        public string lastName;
        public string email;
        public User(){}
        public User(string firstName, string lastName, string email)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
        }
    }
}