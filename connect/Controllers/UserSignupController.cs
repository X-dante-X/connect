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
    
    [ApiController]
    [Route("api/[controller]")]
    public class UserSignupController : ControllerBase
    {
        [EnableCors("AllowOrigin")]
        [HttpPost]
        public async Task<JsonResult> Singup(UserSignup user)
        {
            bool good = false;
            using (var connection = new SqliteConnection("Data Source = C:\\Users\\48734\\Documents\\GitHub\\connect\\API.db"))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = $"INSERT INTO users ( user_login, user_password,user_email ) VALUES('{user.UserLogin}','{user.UserPassword}','{user.UserEmail}' );";
                command.ExecuteNonQuery();
                connection.Close();
            }
            return new JsonResult(true);
        }

    }
}
