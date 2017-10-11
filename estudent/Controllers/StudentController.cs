using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using estudent.Models;

namespace estudent.Controllers
{
    public class StudentController : Controller
    {
        private estudentDBContext db = new estudentDBContext();

        // GET: Student
        public ActionResult Index(int? id)
        {
            ViewBag.studentIsSelected = false;
            List<Student> studenti = db.Studenti.ToList();

            if (!id.HasValue || id == 0)
                return View(studenti);

            List<Student> found = studenti.Where(x => x.ID == id).ToList();
            if(found.Count() == 0)
                return View(studenti);

            
            
            InfoBoxViewData dat = new InfoBoxViewData();
            dat.selectedStudent = found.First();
            dat.passedExams = db.Ispiti.Where(x => x.BI == dat.selectedStudent.BI).ToList();
            dat.avg = dat.passedExams.Count > 0 ? dat.passedExams.Average(x => x.Ocena).ToString("N2") : "N.A.";

            ViewBag.studentIsSelected = true;
            ViewBag.infoBoxViewData = dat;

            return View(studenti);
        }


        // GET: Student/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Studenti.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }

            InfoBoxViewData dat = new InfoBoxViewData();
            dat.passedExams = db.Ispiti.Where(x => x.BI == student.BI).ToList();
            dat.avg = dat.passedExams.Count>0 ? dat.passedExams.Average(x => x.Ocena).ToString("N2") : "N.A.";
            dat.selectedStudent = student;

            return View(dat);
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,BI,Ime,Prezime,Adresa,Grad")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Studenti.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(student);
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Studenti.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Student/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,BI,Ime,Prezime,Adresa,Grad")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Studenti.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Studenti.Find(id);
            db.Studenti.Remove(student);
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

        void resetDB()
        {
            string[] sArrayS = System.IO.File.ReadAllLines(Server.MapPath("~/App_Data/studenti.txt"));
            string[] iArrayS = System.IO.File.ReadAllLines(Server.MapPath("~/App_Data/ispiti.txt"));
            int cnt;

            db.Studenti.RemoveRange(db.Studenti);
            db.Ispiti.RemoveRange(db.Ispiti);

            cnt = 1;
            foreach (string row in sArrayS)
            {
                string[] studentSplited = row.Split(new char[] {'\t'});
                Student s = new Student();
                s.ID = cnt++;//int.Parse(studentSplited[0]);
                s.BI = studentSplited[0];
                s.Ime = studentSplited[1];
                s.Prezime = studentSplited[2];
                s.Adresa = studentSplited[3];
                s.Grad = studentSplited[4];

                db.Studenti.Add(s);
            }

            cnt = 1;
            foreach (string row in iArrayS)
            {
                string[] ispitSplited = row.Split(new char[]{'\t'});
                Ispit i = new Ispit();
                i.ID = cnt++;//int.Parse(ispitSplited[0]);
                i.BI = ispitSplited[0];
                i.Predmet = ispitSplited[1];
                i.Ocena = int.Parse(ispitSplited[2]);

                db.Ispiti.Add(i);
            }
            db.SaveChanges();
        }

        void downloadDB()
        {
            char[] tabSeparator = { '\t' };
            string[] sArrayS = System.IO.File.ReadAllLines(Server.MapPath("~/App_Data/studenti.csv"));
            string[] iArrayS = System.IO.File.ReadAllLines(Server.MapPath("~/App_Data/ispiti.csv"));
            int cnt;

            db.Studenti.RemoveRange(db.Studenti);
            db.Ispiti.RemoveRange(db.Ispiti);

            cnt = 13;//TODO: .. 1
            foreach (string row in sArrayS)
            {
                string[] studentSplited = row.Split(tabSeparator);
                Student s = new Student();
                s.ID = cnt++;//int.Parse(studentSplited[0]);
                s.BI = studentSplited[0];
                s.Ime = studentSplited[1];
                s.Prezime = studentSplited[2];
                s.Adresa = studentSplited[3];
                s.Grad = studentSplited[4];

                db.Studenti.Add(s);
            }

            cnt = 13;//TODO: .. 1
            foreach (string row in iArrayS)
            {
                string[] ispitSplited = row.Split(tabSeparator);
                Ispit i = new Ispit();
                i.ID = cnt++;//int.Parse(ispitSplited[0]);
                i.BI = ispitSplited[0];
                i.Predmet = ispitSplited[1];
                i.Ocena = int.Parse(ispitSplited[2]);

                db.Ispiti.Add(i);
            }
            db.SaveChanges();
        }

        void backupDB()
        {
            List<Student> studenti = db.Studenti.ToList();
            List<Ispit> ispiti = db.Ispiti.ToList();

            System.IO.File.WriteAllLines(Server.MapPath("~/App_Data/studenti.csv"), Array.ConvertAll(studenti.ToArray(),
                new Converter<Student, string>(x => (x.ID + "\t" + x.BI + "\t" + x.Ime + "\t" + x.Prezime + "\t" + x.Adresa + "\t" + x.Grad + "\n"))
                ));
            System.IO.File.WriteAllLines(Server.MapPath("~/App_Data/ispiti.csv"), Array.ConvertAll(ispiti.ToArray(),
                new Converter<Ispit, string>(x => (x.ID + "\t" + x.BI + "\t" + x.Predmet + "\t" + x.Ocena + "\n"))
                ));
        }
    }
}
