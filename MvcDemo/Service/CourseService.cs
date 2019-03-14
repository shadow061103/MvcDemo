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
        private static readonly Lazy<CourseService> LazyInstance = new Lazy<CourseService>(() => new CourseService());
        
        public static CourseService Instance { get { return LazyInstance.Value; } }

        ICourseRepository<Course> repository;
        private CourseService()
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
        public bool CreateCourse(Course model)
        {
            var courses = GetCourses().Where(c => c.CourseName.Equals(model.CourseName));
            if (courses.Count() == 0)
            {
                repository.Create(model);
                return true;
            }
            else
                return false;
            
        }
        public bool UpdateCourse(Course model)
        {
            var courses = GetCourses().Where(c => c.CourseName.Equals(model.CourseName) && c.Id!=model.Id);
            if (courses.Count() == 0)
            {
                repository.Update(model);
                return true;
            }
            else
                return false;
                
        }
        public void DeleteCourse(int Id)
        {
            repository.Delete(Id);
        }

    }
}