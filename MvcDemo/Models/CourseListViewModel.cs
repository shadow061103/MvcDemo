using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcDemo.Models
{
    public class CourseListViewModel
    {
        public IPagedList<Course> course { get; set; }
        public int PageIndex { get; set; }
        public CourseListViewModel()
        {
            PageIndex = 1;
        }
    }
}