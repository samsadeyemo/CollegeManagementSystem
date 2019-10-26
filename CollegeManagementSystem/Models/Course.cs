using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CollegeManagementSystem.Models
{
    public class Course
    {
        [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Course Title is required"), Display(Name = "Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Course Code is required"), Display(Name = "Code")]
        public string Code { get; set; }

        public virtual ICollection<Subject> Subjects { get; set; }


    }
}