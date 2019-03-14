using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcDemo.Models
{
    public class Course
    {
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        [RegularExpression("^([-\u4e00-\u9fa5a-zA-Z0-9]{1,20})$",ErrorMessage ="格式有誤")]
        public string CourseName { get; set; }
        [Required]
        [StringLength(50)]
        [RegularExpression("^([-\u4e00-\u9fa5a-zA-Z0-9]{1,50})$", ErrorMessage = "格式有誤")]
        public string Location { get; set; }
        public int Status { get; set; }
    }
}