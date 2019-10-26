using CollegeManagementSystem.Models;
using System;
using System.Collections.Generic;

namespace CollegeManagementSystem.DataSeedModel
{
    public class DataInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<SchoolCMSContext>
    {
        protected override void Seed(SchoolCMSContext context)
        {
            var course = new List<Course>
            {
             new Course{Title="Computer Science",Code="CSC"},
              new Course{Title="Robotics",Code="ROB"},
               new Course{Title="Law",Code="LAW"},
                new Course{Title="Physics",Code="PHY"},
                 new Course{Title="Biochemistry",Code="BIOCHEM"}
            };
            course.ForEach(s => context.Courses.Add(s));
            context.SaveChanges();

            var grade = new List<Grade>
            {
             new Grade{GradeName="A",GradeScore=5},
               new Grade{GradeName="B",GradeScore=4},
                 new Grade{GradeName="C",GradeScore=3},
                   new Grade{GradeName="D",GradeScore=2},
                     new Grade{GradeName="E",GradeScore=1},
                       new Grade{GradeName="F",GradeScore=0}
            };
            grade.ForEach(s => context.Grades.Add(s));
            context.SaveChanges();

           

            var teacher = new List<Teacher>
            {
            new Teacher{Name="Damon See",Birthday=DateTime.Parse("1970-01-11"),Salary=234.89m},
             new Teacher{Name="Samson Adeyemo",Birthday=DateTime.Parse("1988-01-11"),Salary=500},
              new Teacher{Name="Fayk Delly",Birthday=DateTime.Parse("1980-12-11"),Salary=100.85m},
               new Teacher{Name="Dapsy Jikky",Birthday=DateTime.Parse("1981-01-11"),Salary=67.00m},
                new Teacher{Name="Wumite Seerthy",Birthday=DateTime.Parse("1990-01-11"),Salary=700.43m}
              };
            teacher.ForEach(s => context.Teachers.Add(s));
            context.SaveChanges();

            var subject = new List<Subject>
            {
             new Subject{Name="Mathematics",TeacherId=1,CourseId=1},
              new Subject{Name="English",TeacherId=2,CourseId=2},
               new Subject{Name="Science",TeacherId=3,CourseId=3},
                new Subject{Name="Biology",TeacherId=4,CourseId=4},
                 new Subject{Name="Civic",TeacherId=5,CourseId=5}
            };
            subject.ForEach(s => context.Subjects.Add(s));
            context.SaveChanges();

            var students = new List<Student>
            {
            new Student{FullName="Cristiano Ronaldo",RegNumber="0901",Birthday=DateTime.Parse("2000-01-11"),SubjectId=1,GradeId=1},
             new Student{FullName="Matt Lee",RegNumber="0702",Birthday=DateTime.Parse("2001-09-30"),SubjectId=2,GradeId=2},
              new Student{FullName="Nani Luis",RegNumber="0103",Birthday=DateTime.Parse("2002-11-11"),SubjectId=3,GradeId=3},
               new Student{FullName="Case Iner",RegNumber="1104",Birthday=DateTime.Parse("1988-02-01"),SubjectId=4,GradeId=4},
                new Student{FullName="Jorge Hose",RegNumber="7805",Birthday=DateTime.Parse("1990-04-21"),SubjectId=5,GradeId=5}
            };
            students.ForEach(s => context.Students.Add(s));
            context.SaveChanges();

           
        }
    }
}