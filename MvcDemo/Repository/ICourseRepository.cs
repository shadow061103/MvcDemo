using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcDemo.Models;
namespace MvcDemo.Repository
{
    public interface ICourseRepository<T>
    {
         T GetById(int Id);
         IEnumerable<T> Get();
        void Update(T entity);
        void Delete(int Id);
        void Create(T entity);


    }
}