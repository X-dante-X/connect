using connect.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data;
using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections;
using Microsoft.AspNetCore.Cors;

namespace connect.Controllers
{
    public class login
    { 
        public string Login { get; set; }   
        public string Password { get; set; }

        public login(string login, string password) 
        {
            Login = login;
            Password = password;    
        }   
    }
    [ApiController]
    [Route("api/[controller]")]
    public class UserSigninController : ControllerBase
    {
        [EnableCors("AllowOrigin")]
        [HttpPost]
        public JsonResult Singin(UserSignin user)
        {
            ArrayList users = new ArrayList();
            bool good = false;
            using (var connection = new SqliteConnection("Data Source = C:\\Users\\48734\\Documents\\GitHub\\connect\\API.db"))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT user_login, user_password FROM users where (user_login = @UserLogin or user_email = @UserEmail) and user_password = @UserPassword";
                command.Parameters.AddWithValue("@UserLogin", user.UserLogin);
                command.Parameters.AddWithValue("@UserEmail", user.UserLogin);
                command.Parameters.AddWithValue("@UserPassword", user.UserPassword);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        users.Add(new login(reader.GetString(0), reader.GetString(1)));
                    }
                    good = reader.VisibleFieldCount > 0 ? true : false;
                }
                connection.Close();
            }
            if (good) return new JsonResult(users);
            else return new JsonResult(good);
        }

    }
}
