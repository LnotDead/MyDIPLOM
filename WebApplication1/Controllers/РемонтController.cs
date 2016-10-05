using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Authorize]
    public class РемонтController : Controller
    {
        private DB_for_service_supportEntities db = new DB_for_service_supportEntities();

        // GET: Ремонт
        public async Task<ActionResult> Index()
        {
            var ремонт = db.Ремонт.Include(р => р.Тренажёры).Include(р => р.Сотрудники);
            return View(await ремонт.ToListAsync());
        }

        // GET: Ремонт/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ремонт ремонт = await db.Ремонт.FindAsync(id);
            if (ремонт == null)
            {
                return HttpNotFound();
            }
            return View(ремонт);
        }

        // GET: Ремонт/Create
        public ActionResult Create()
        {
            ViewBag.Начало_SN = new SelectList(db.Тренажёры, "Начало_SN", "Примечания");
            ViewBag.ID_сотрудника = new SelectList(db.Сотрудники, "ID_сотрудника", "ФИО_сотрудника");
            return View();
        }

        // POST: Ремонт/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID_ремонта,Начало_SN,Конец_SN,ID_сотрудника,Начало,Завершение,Примечания")] Ремонт ремонт)
        {
            if (ModelState.IsValid)
            {
                db.Ремонт.Add(ремонт);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Начало_SN = new SelectList(db.Тренажёры, "Начало_SN", "Примечания", ремонт.Начало_SN);
            ViewBag.ID_сотрудника = new SelectList(db.Сотрудники, "ID_сотрудника", "ФИО_сотрудника", ремонт.ID_сотрудника);
            return View(ремонт);
        }

        // GET: Ремонт/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ремонт ремонт = await db.Ремонт.FindAsync(id);
            if (ремонт == null)
            {
                return HttpNotFound();
            }
            ViewBag.Начало_SN = new SelectList(db.Тренажёры, "Начало_SN", "Примечания", ремонт.Начало_SN);
            ViewBag.ID_сотрудника = new SelectList(db.Сотрудники, "ID_сотрудника", "ФИО_сотрудника", ремонт.ID_сотрудника);
            return View(ремонт);
        }

        // POST: Ремонт/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID_ремонта,Начало_SN,Конец_SN,ID_сотрудника,Начало,Завершение,Примечания")] Ремонт ремонт)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ремонт).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Начало_SN = new SelectList(db.Тренажёры, "Начало_SN", "Примечания", ремонт.Начало_SN);
            ViewBag.ID_сотрудника = new SelectList(db.Сотрудники, "ID_сотрудника", "ФИО_сотрудника", ремонт.ID_сотрудника);
            return View(ремонт);
        }

        // GET: Ремонт/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ремонт ремонт = await db.Ремонт.FindAsync(id);
            if (ремонт == null)
            {
                return HttpNotFound();
            }
            return View(ремонт);
        }

        // POST: Ремонт/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Ремонт ремонт = await db.Ремонт.FindAsync(id);
            db.Ремонт.Remove(ремонт);
            await db.SaveChangesAsync();
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
