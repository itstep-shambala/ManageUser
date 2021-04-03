using System;
using ModelData;
using static ModelData.Account;
using static ModelData.User;
using static ModelData.InputData;

namespace ManageUser
{
    class Program
    {
        static void Main(string[] args)
        {
            //классы сохранения данных пользователя
            Account account = new Account();
            User user = new User();
            Role role = new Role();
            //ввод данных
            account = InputAccount();
            role = InputRole();
            user = InputUser();
            //подключение к БД
            //DBConnect dbRegistrationAccount = new DBConnect();
            DBConnect dbRegistrationRole = new DBConnect();
            DBConnect dbRegistrationUser = new DBConnect();
            // if (dbRegistrationAccount.RegistrationAccount(account.login, account.password))&&
            if (dbRegistrationRole.RegistrationRole(role.name) && dbRegistrationUser.RegistrationUser(user.firstName, user.lastName, user.email))
            {
                Console.WriteLine("Пользователь зарегистрирован");
            }
            else
            {
                Console.WriteLine("Пользователь НЕ зарегистрирован");
            }
        }
    }
}