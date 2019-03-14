using MvcDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcDemo.Service;
using PagedList;

namespace MvcDemo.Controllers
{
    public class CourseController : Controller
    {
        private const int PageSize = 5;//每頁呈現筆數
        // GET: Course
        public ActionResult Index()
        {
            var model = new CourseListViewModel()
            {
                course=CourseService.Instance.GetCourses().OrderBy(c => c.Id).ToPagedList(1, PageSize)
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(CourseListViewModel model)
        {
            int pageIndex = model.PageIndex < 1 ? 1 : model.PageIndex;
            model.course = CourseService.Instance.GetCourses().OrderBy(c => c.Id).ToPagedList(pageIndex, PageSize);

            return View(model);
        }
        public ActionResult Create()
        {
            var model = new CreateViewModel()
            {
                course = new Course()
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(CreateViewModel model)
        {
            if (ModelState.IsValid)
            {
              bool result=  CourseService.Instance.CreateCourse(model.course);
                if (!result)
                    ModelState.AddModelError("course.CourseName", "已有此課程");
                else
                    return RedirectToAction("Index");
            }
            else
                return View(model);

            return View();
        }
        public ActionResult Update(int Id)
        {
            var model = CourseService.Instance.GetCourseById(Id);
            if (model == null)
                ModelState.AddModelError("course.CourseName", "無此課程");
            
            return View(model);
        }
        [HttpPost]
        public ActionResult Update(Course model)
        {
            if (ModelState.IsValid)
            {
                bool result = CourseService.Instance.UpdateCourse(model);
                if (!result)
                    ModelState.AddModelError("course.CourseName", "已有此課程");
                else
                    return RedirectToAction("Index");
            }
            else
                return View(model);

            return View();
        }

        [HttpPost]
        public ActionResult Delete(int Id)
        {
            try
            {
                CourseService.Instance.DeleteCourse(Id);
                return Json(new { success =  true , ex = "刪除成功" },
                 JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, ex = "刪除失敗"+ex.Message },
                 JsonRequestBehavior.AllowGet);
            }
           


            
        }
    }
}