using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CollegeManagementSystem.DataSeedModel;
using CollegeManagementSystem.Models;

namespace CollegeManagementSystem.Controllers
{
    public class StudentsController : Controller
    {
        private SchoolCMSContext db = new SchoolCMSContext();

        // GET: Students
        public ActionResult Index()
        {
            var students = db.Students.Include(s => s.Subject).Include(s=>s.Grade);
            return View(students.ToList());
        }

        // StudentsWithTeacherInfo
        public ActionResult StudentsWithTeacherInfo()
        {
            var students = db.Students.Include(s => s.Subject).Include(s => s.Grade).Include(s => s.Subject.Teacher).Include(s => s.Subject.Students);
            return View(students.ToList());
        }


        //ViewTeacherInfo 
        public ActionResult ViewTeacherInfo(int? id)
        {
            var students = db.Students.Where(p=>p.Subject.TeacherId == id).Include(s => s.Subject).Include(s => s.Grade).Include(s => s.Subject.Teacher).Include(s => s.Subject.Students);
            return View(students.FirstOrDefault());
        }

        // ViewSubjectStudentGrade
        public ActionResult ViewSubjectStudentGrade(int? id)
        {
            var students = db.Students.Where(p => p.Subject.Id == id).Include(s => s.Subject).Include(s => s.Grade).Include(s => s.Subject.Teacher).Include(s => s.Subject.Students);
            return View(students.ToList());
        }

        // StudentsWithGrades
        public ActionResult StudentsWithGrades()
        {
            var students = db.Students.Include(s => s.Subject).Include(s => s.Grade);
            return View(students.ToList());
        }
       //  StudentsWithGradesDetails
        public ActionResult StudentsWithGradesDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "Name");
            ViewBag.GradeId = new SelectList(db.Grades, "Id", "GradeName");
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FullName,RegNumber,Birthday,SubjectId,GradeId")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "Name", student.SubjectId);
            ViewBag.GradeId = new SelectList(db.Grades, "Id", "GradeName", student.GradeId);
            return View(student);
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "Name", student.SubjectId);
            ViewBag.GradeId = new SelectList(db.Grades, "Id", "GradeName", student.GradeId);
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FullName,RegNumber,Birthday,SubjectId,GradeId")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "Name", student.SubjectId);
            ViewBag.GradeId = new SelectList(db.Grades, "Id", "GradeName", student.GradeId);
            return View(student);
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
