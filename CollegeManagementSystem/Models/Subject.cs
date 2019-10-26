using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CollegeManagementSystem.Models
{
    public class Subject
    {

        [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Subject Name is required"), Display(Name = "Subject")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Course is required"), Display(Name = "Course")]
        public int CourseId { get; set; }

        public virtual Course Course { get; set; }      

        [Required(ErrorMessage = "Teacher is required"), Display(Name = "Teacher")]
        public int TeacherId { get; set; }

        public virtual Teacher Teacher { get; set; }

        public virtual ICollection<Student> Students { get; set; }

    }
}