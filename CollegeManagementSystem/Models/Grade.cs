using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CollegeManagementSystem.Models
{
    public class Grade
    {
        [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Grade is required"), Display(Name = "Grade")]
        [StringLength(1, ErrorMessage = "Grade can only be one aphabet")]
        public string GradeName { get; set; }

        [Required(ErrorMessage = "Grade Score is required"), Display(Name = "Score")]
        public int GradeScore { get; set; }

        public virtual ICollection<Student> Students { get; set; }

    }
}