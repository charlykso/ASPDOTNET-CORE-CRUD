using System;
using System.Linq;
using System.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using blog.Models;
using blog.ViewModels;

namespace blog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController: ControllerBase
    {
        private readonly IConfiguration _configuration;
        public PostController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                select * from dbo.Post
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("BlogAppCon");
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

        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            string query = @"
                select * from dbo.Post
                where id = @id
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("BlogAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@id", id);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }


        [HttpPost]
        public JsonResult Post(PostModel post)
        {
            
            Post data = new Post();
            data.title = post.title;
            data.author = post.author;
            data.body = post.body;
            data.created_at = DateTime.Now;
            // DateTime myDateTime = DateTime.Now;
            // var mySecondDate = myDateTime.ToString("dd/MM/yy HH:mm:ss");
            // Console.WriteLine(mySecondDate);
            string query = @"
                insert into dbo.Post
                values(@author, @title, @body, @created_at)
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("BlogAppCon");
            SqlDataReader myReader;
            try
            {
                using (SqlConnection myCon = new SqlConnection(sqlDataSource))
                {
                    myCon.Open();
                    using (SqlCommand myCommand = new SqlCommand(query, myCon))
                    {

                        myCommand.Parameters.AddWithValue("@author", data.author);
                        myCommand.Parameters.AddWithValue("@title", data.title);
                        myCommand.Parameters.AddWithValue("@body", data.body);
                        myCommand.Parameters.AddWithValue("@created_at", data.created_at);
                        myReader = myCommand.ExecuteReader();
                        table.Load(myReader);
                        myReader.Close();
                        myCon.Close();
                    }
                }
            }
            catch (System.Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

            return new JsonResult("Post Created Successfuly");
        }

        [HttpPut]
        public JsonResult Put(Post post)
        {
            string query = @"
                update dbo.Post
                set title = @title, author = @author, body = @body, created_at = @created_at
                where id = @id
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("BlogAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@id", post.id);
                    myCommand.Parameters.AddWithValue("@title", post.title);
                    myCommand.Parameters.AddWithValue("@author", post.author);
                    myCommand.Parameters.AddWithValue("@body", post.body);
                    myCommand.Parameters.AddWithValue("@created_at", post.created_at);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Post Updated Successfuly");
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"
                delete from dbo.Post
                where id = @id
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("BlogAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@id", id);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Post Deleted Successfuly");
        }
        
    }
}