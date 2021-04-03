using System;
using MySql.Data.MySqlClient;

namespace ModelData
{
    public class DBConnect
    {
        string conn_str = "Server=mysql60.hostland.ru;Database=host1323541_itstep37;Uid=host1323541_itstep;Pwd=269f43dc;";
        private MySqlConnection connection;
        public DBConnect()
        {
            //подключение к БД
            connection = new MySqlConnection(conn_str);
            connection.Open();
        }
        public bool RegistrationAccount(string login,string password)
        {
            var sql = $"INSERT INTO host1323541_itstep37.table_account (login, password) VALUES ('{login}', '{password}');";
            var commandAccount = new MySqlCommand
            {
                Connection = connection, 
                CommandText = sql
            };
            var result = commandAccount.ExecuteNonQuery();
            if (result == 0)
            {
                connection.Close();
                return false;
            }
            else
            {
                connection.Close();
                return true;
            }
        }
        public bool RegistrationRole(string role)
        {
            var sql = $"INSERT INTO host1323541_itstep37.table_role (name) VALUES ('{role}');";
            var commandAccount = new MySqlCommand
            {
                Connection = connection, 
                CommandText = sql
            };
            var result = commandAccount.ExecuteNonQuery();
            if (result == 0)
            {
                connection.Close();
                return false;
            }
            else
            {
                connection.Close();
                return true;
            }
        }
        public bool RegistrationUser(string firstName,string lastName,string email)
        {
            var sql =
                $"INSERT INTO host1323541_itstep37.table_user (first_name, last_name, email) VALUES ('{firstName}', '{lastName}', '{email}');";
            var commandUser = new MySqlCommand
            {
                Connection = connection, 
                CommandText = sql
            };
            var result = commandUser.ExecuteNonQuery();
            if (result==0)
            {
                connection.Close();
                return false;
            }
            else
            {
                connection.Close();
                return true;
            }
        }
        
    }
}