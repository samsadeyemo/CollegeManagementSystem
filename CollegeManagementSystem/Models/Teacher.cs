using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CollegeManagementSystem.Models
{
    public class Teacher
    {
        [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage ="Teacher Name is required"),Display(Name="Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Teacher Birthday is required"), Display(Name = "Birthday")]
        public DateTime Birthday { get; set; }

        [Required(ErrorMessage = "Teacher Salary is required"), Display(Name = "Salary")]
        public decimal Salary { get; set; }

        public virtual ICollection<Subject> Subjects { get; set; }

    }
}