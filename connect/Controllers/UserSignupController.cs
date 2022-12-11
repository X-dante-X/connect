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
    
    [ApiController]
    [Route("api/[controller]")]
    public class UserSignupController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public UserSignupController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Singup(UserSignup user)
        {
            ArrayList users = new ArrayList();
            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                
                var command = connection.CreateCommand();
                command.CommandText = $"INSERT INTO users (user_login, user_password,user_email) VALUES('{user.UserLogin}','{user.UserPassword}','{user.UserEmail}');";

                using (var reader = command.ExecuteReader())
                {

                }
                connection.Close();
            }
            return new JsonResult(users);
        }

    }
}
