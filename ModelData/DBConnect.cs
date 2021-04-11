using MySql.Data.MySqlClient;
using static ModelData.ClassConnect;
using System.IO;
using System.Text.Json;

namespace ModelData
{
    public class DBConnect
    {
        private static ClassConnect classConnect = new ClassConnect
        {
            Server = "mysql60.hostland.ru",
            Database = "host1323541_itstep37",
            Uid = "host1323541_itstep",
            Pwd = "269f43dc"
        };

        private static ClassConnect newClassConnect = new ClassConnect();
        public static void OutputPath()
        {
            using (StreamWriter file = new StreamWriter("classConnect.json", false))
            {
                string json = JsonSerializer.Serialize(classConnect);
                file.WriteLine(json);
            }
        }

        public static string InputPath()
        {
            ClassConnect classConnect = new ClassConnect();
            using (FileStream file = new FileStream("classConnect.json", FileMode.Open))
            {
                classConnect = JsonSerializer.DeserializeAsync<ClassConnect>(file).Result;
            }
            string conn_str = $"Server={classConnect.Server};Database={classConnect.Database};Uid={classConnect.Uid};Pwd{classConnect.Pwd};";
            return conn_str;
        }
        //string conn_str = "Server=mysql60.hostland.ru;Database=host1323541_itstep37;Uid=host1323541_itstep;Pwd=269f43dc;";
        private MySqlConnection connection;
        public DBConnect()
        {
            //подключение к БД
            connection = new MySqlConnection(InputPath());
        }
        public bool RegistrationAccount(string login,string password)
        {
            connection.Open();
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
            connection.Open();
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
            connection.Open();
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