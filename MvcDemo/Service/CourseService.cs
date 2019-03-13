using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcDemo.Repository;
using MvcDemo.Models;
using MvcDemo.Factory;
namespace MvcDemo.Service
{
    public class CourseService
    {
        ICourseRepository<Course> repository;
        public CourseService()
        {
            repository= GenericFactory.CreateInastance<ICourseRepository<Course>>(typeof(CourseRepository));
        }
        public Course GetCourseById(int Id)
        {
            return repository.GetById(Id);

        }
        public IEnumerable<Course> GetCourses()
        {
            return repository.Get();
        }
        public void CreateCourse(Course model)
        {
            repository.Create(model);
        }
        public void UpdateCourse(Course model)
        {
            repository.Update(model);
        }
        public void DeleteCourse(int Id)
        {
            repository.Delete(Id);
        }

    }
}