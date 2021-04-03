using System;
using static ModelData.Account;
using static ModelData.User;
using static ModelData.Role;

namespace ModelData
{
    public class InputData
    {
        public static Account InputAccount()
        {
            Console.WriteLine("Введите логин");
            string login = Console.ReadLine();
            Console.WriteLine("Введите пароль");
            string password = Console.ReadLine();

            Account account = new Account(login, password);
            return account;
        }
        public static Role InputRole()
        {
            Console.WriteLine("Введите роль пользователя");
            string _role = Console.ReadLine();
            Role role = new Role(_role);
            return role;
        }
        public static User InputUser()
        {
            Console.WriteLine("Введите имя");
            string firstName = Console.ReadLine();
            Console.WriteLine("Введите фамилию");
            string lastName = Console.ReadLine();
            Console.WriteLine("Введите email");
            string email = Console.ReadLine();
            User user = new User(firstName, lastName, email);
            return user;
        }
    }
}