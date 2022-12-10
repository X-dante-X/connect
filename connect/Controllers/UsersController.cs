using connect.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data;
using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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

        /*[HttpGet]
        public JsonResult Signin(User user)
        {
            string query = @"select user_login from users ";*//*where user_login = {user.UserLogin} and user_passwoed {user.UserPassword}; *//*

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DefaultConnection");
            Console.WriteLine(sqlDataSource);
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query,myCon))
                { 
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult(query);
        }*/

        [HttpGet]
        public JsonResult Singin()
        {
            List<test> users = new List<test>();
            using (var connection = new SqliteConnection("Data Source=D:\\sqlite\\API.db"))
            {
                connection.Open();
                
                var command = connection.CreateCommand();
                command.CommandText = $"SELECT user_login, user_password FROM users";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        users.Add(new test(reader.GetString(0), reader.GetString(1)));
                    }
                }
                connection.Close();
            }
            return new JsonResult(users[0]);
        }

        [HttpPost]
        public JsonResult Signup(User user)
        {
            string query = $"insert into users values('{user.UserLogin}','{user.UserPassword}','{user.UserEmail}',DEFAULT)";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DefaultConnection");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult(table);
        }

    }
}
