using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CollegeManagementSystem.Models
{
    public class Student
    {
        [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Student FullName is required"), Display(Name = "FullName")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Registation Number is required"), Display(Name = "Registation Number")]
        public string RegNumber { get; set; }

        [Required(ErrorMessage = "Birthday is required"), Display(Name = "Birthday")]
        public DateTime Birthday { get; set; }

        [Required(ErrorMessage = "Subject is required"), Display(Name = "Subject")]
        public int SubjectId { get; set; }

        public virtual Subject Subject { get; set; }

        [Required(ErrorMessage = "Grade is required"), Display(Name = "Grade")]
        public int GradeId { get; set; }

        public virtual Grade Grade { get; set; }
            

    }
}