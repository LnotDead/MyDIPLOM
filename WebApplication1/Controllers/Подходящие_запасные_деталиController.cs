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
    public class Подходящие_запасные_деталиController : Controller
    {
        private DB_for_service_supportEntities db = new DB_for_service_supportEntities();

        // GET: Подходящие_запасные_детали
        public async Task<ActionResult> Index()
        {
            var подходящие_запасные_детали = db.Подходящие_запасные_детали.Include(п => п.Модели_тренажёров).Include(п => п.Склад_запасных_деталей);
            return View(await подходящие_запасные_детали.ToListAsync());
        }

        // GET: Подходящие_запасные_детали/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Подходящие_запасные_детали подходящие_запасные_детали = await db.Подходящие_запасные_детали.FindAsync(id);
            if (подходящие_запасные_детали == null)
            {
                return HttpNotFound();
            }
            return View(подходящие_запасные_детали);
        }

        // GET: Подходящие_запасные_детали/Create
        public ActionResult Create()
        {
            ViewBag.Начало_SN = new SelectList(db.Модели_тренажёров, "Начало_SN", "Тип_тренажёра");
            ViewBag.Код_детали = new SelectList(db.Склад_запасных_деталей, "Код_детали", "Примечания");
            return View();
        }

        // POST: Подходящие_запасные_детали/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Код_детали,Начало_SN")] Подходящие_запасные_детали подходящие_запасные_детали)
        {
            if (ModelState.IsValid)
            {
                db.Подходящие_запасные_детали.Add(подходящие_запасные_детали);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Начало_SN = new SelectList(db.Модели_тренажёров, "Начало_SN", "Тип_тренажёра", подходящие_запасные_детали.Начало_SN);
            ViewBag.Код_детали = new SelectList(db.Склад_запасных_деталей, "Код_детали", "Примечания", подходящие_запасные_детали.Код_детали);
            return View(подходящие_запасные_детали);
        }

        // GET: Подходящие_запасные_детали/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Подходящие_запасные_детали подходящие_запасные_детали = await db.Подходящие_запасные_детали.FindAsync(id);
            if (подходящие_запасные_детали == null)
            {
                return HttpNotFound();
            }
            ViewBag.Начало_SN = new SelectList(db.Модели_тренажёров, "Начало_SN", "Тип_тренажёра", подходящие_запасные_детали.Начало_SN);
            ViewBag.Код_детали = new SelectList(db.Склад_запасных_деталей, "Код_детали", "Примечания", подходящие_запасные_детали.Код_детали);
            return View(подходящие_запасные_детали);
        }

        // POST: Подходящие_запасные_детали/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Код_детали,Начало_SN")] Подходящие_запасные_детали подходящие_запасные_детали)
        {
            if (ModelState.IsValid)
            {
                db.Entry(подходящие_запасные_детали).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Начало_SN = new SelectList(db.Модели_тренажёров, "Начало_SN", "Тип_тренажёра", подходящие_запасные_детали.Начало_SN);
            ViewBag.Код_детали = new SelectList(db.Склад_запасных_деталей, "Код_детали", "Примечания", подходящие_запасные_детали.Код_детали);
            return View(подходящие_запасные_детали);
        }

        // GET: Подходящие_запасные_детали/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Подходящие_запасные_детали подходящие_запасные_детали = await db.Подходящие_запасные_детали.FindAsync(id);
            if (подходящие_запасные_детали == null)
            {
                return HttpNotFound();
            }
            return View(подходящие_запасные_детали);
        }

        // POST: Подходящие_запасные_детали/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            Подходящие_запасные_детали подходящие_запасные_детали = await db.Подходящие_запасные_детали.FindAsync(id);
            db.Подходящие_запасные_детали.Remove(подходящие_запасные_детали);
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
