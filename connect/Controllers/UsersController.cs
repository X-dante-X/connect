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
    public class UsersController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public UsersController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
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
        }

    }
}
