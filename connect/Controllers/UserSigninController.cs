using connect.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data;
using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections;

namespace connect.Controllers
{
    public class test
    { 
        public string Login { get; set; }   
        public string Password { get; set; }

        public test(string login, string password) 
        {
            Login = login;
            Password = password;    
        }   
    }
    [ApiController]
    [Route("api/[controller]")]
    public class UserSigninController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public UserSigninController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /*        [HttpGet]
                public JsonResult Singin()
                {
                    ArrayList users = new ArrayList();
                    using (var connection = new SqliteConnection("Data Source=C:\\Users\\48734\\Desktop\\api.db"))
                    {
                        connection.Open();

                        var command = connection.CreateCommand();
                        command.CommandText = $"SELECT email, password FROM users";

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                users.Add(new test(reader.GetString(0), reader.GetString(1)));
                            }
                        }
                        connection.Close();
                    }
                    return new JsonResult(users);
                }*/

        [HttpGet]
        public JsonResult Singin(UserSignin user)
        {
            ArrayList users = new ArrayList();
            int check = 0;
            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText = $"SELECT count(user_id) FROM users where (user_login = {user.UserLogin} or user_email = {user.UserLogin}) and user_password = {user.UserPassword}";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        check = int.Parse(reader.GetString(0));
                    }
                }
                if (check > 0)
                {
                    command.CommandText = $"SELECT user_login user_password FROM users where (user_login = {user.UserLogin} or user_email = {user.UserLogin}) and user_password = {user.UserPassword}";
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            users.Add(new test(reader.GetString(0), reader.GetString(1)));
                        }
                    }
                }
                else
                {
                    connection.Close();
                    return new JsonResult(check);
                }

                connection.Close();
            }
            return new JsonResult(users);
        }

    }
}
