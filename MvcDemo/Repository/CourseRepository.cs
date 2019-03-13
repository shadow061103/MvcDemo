using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcDemo.Models;
using System.Data.SqlClient;
using System.Web.Configuration;
using Dapper;
using System.Data;

namespace MvcDemo.Repository
{
    public class CourseRepository : ICourseRepository<Course>
    {
        SqlConnection con = new SqlConnection(
            WebConfigurationManager.ConnectionStrings["FitnessCenterConnectionString"].ConnectionString);
        public Course GetById(int Id)
        {
            Course model;
            con.Open();
            var para = new DynamicParameters();
            para.Add("@Id", Id, DbType.Int32, ParameterDirection.Input, size: 100);
            try
            {
                model = con.Query<Course>("select * from Course where Id=@Id",
                    para, commandTimeout: 300, commandType: CommandType.Text)
                    .FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return model;

        }
        public IEnumerable<Course> Get()
        {

            IEnumerable<Course> model;
            con.Open();
            try
            {
               model = con.Query<Course>("select * from Course",
                    null, commandTimeout: 300, commandType: CommandType.Text)
                    .AsEnumerable();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return model;

        }
        public void Update(Course entity)
        {
            var para = new DynamicParameters();
            con.Open();
            para.Add("@Id", entity.Id, DbType.Int32, ParameterDirection.Input, 100);
            para.Add("@CourseName", entity.CourseName, DbType.String, ParameterDirection.Input, 20);
            para.Add("@Location", entity.Location, DbType.String, ParameterDirection.Input, 50);
            try
            {
                con.Execute(@"Update Course set CourseName=@CourseName,Location=@Location where Id=@Id",
                    para, commandTimeout: 300, commandType: CommandType.Text);
                     
            }
            catch (Exception ex)
            {
                throw ex;
            }




        }
        public void Delete(int Id)
        {
            var para = new DynamicParameters();
            con.Open();
            para.Add("@Id", Id, DbType.Int32, ParameterDirection.Input, 100);
            try
            {
                con.Execute(@"Update Course set Status=0 where Id=@Id",
                    para, commandTimeout: 300, commandType: CommandType.Text);

            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public void Create(Course entity)
        {
            var para = new DynamicParameters();
            con.Open();
            para.Add("@Id", entity.Id, DbType.Int32, ParameterDirection.Input, 100);
            para.Add("@CourseName", entity.CourseName, DbType.String, ParameterDirection.Input, 20);
            para.Add("@Location", entity.Location, DbType.String, ParameterDirection.Input, 50);
            try
            {
                con.Execute(@"Insert into Course(CourseName,Location,Status) Values(@CourseName,@Location,1)   where Id=@Id",
                    para, commandTimeout: 300, commandType: CommandType.Text);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}