using System;
using MySql.Data.MySqlClient;

namespace RegistrationAccount
{    
    public class Registration
    {
        private string host = "mysql60.hostland.ru";
        private string dateBase = "host1323541_itstep";
        private string userName = "host1323541_itstep35";
        private string password = "269f43dc";
        
        //кноструктор базы данных
        public Registration(string host, string dateBase, string userName, string password)
        {
            SetDateBaseInfo(host, dateBase, userName, password);
        }

        //метод для передачи сигнатуры базы данных 
        public void SetDateBaseInfo(string host, string dateBase, string userName, string password)
        {
            this.host = host;
            this.dateBase = dateBase;
            this.userName = userName;
            this.password = password;
        }        
        
        //показать всю таблицу
        public void SelectOllItemsInDate()
        {
            ExecuteARequest("SELECT * FROM accounts;");
        }
        
        //создать строку в таблице
        public void InsertNewItemInDate(string email, string password)
        {
            ExecuteARequest($"INSERT INTO accounts VALUES (null, '{email}', '{password}');");
        }
        
        //запрос в базу данных
        private string ExecuteARequest(string request)
        {
            string connectionString = "Server=" + host + ";" + "Database=" + dateBase + ";" + "Uid=" + userName + ";" + "Pwd=" + password + ";charset=utf8;";
           
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {                
                connection.Open();               
                if (!connection.Ping()) { Console.WriteLine("ошибка"); return null; }
              
                var result = new MySqlCommand { Connection = connection, CommandText = request }.ExecuteReader();

                return request;
            }
        }        
    }
}