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
    public class Модели_тренажёровController : Controller
    {
        private DB_for_service_supportEntities db = new DB_for_service_supportEntities();

        // GET: Модели_тренажёров
        public async Task<ActionResult> Index()
        {
            return View(await db.Модели_тренажёров.ToListAsync());
        }

        // GET: Модели_тренажёров/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Модели_тренажёров модели_тренажёров = await db.Модели_тренажёров.FindAsync(id);
            if (модели_тренажёров == null)
            {
                return HttpNotFound();
            }
            return View(модели_тренажёров);
        }

        // GET: Модели_тренажёров/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Модели_тренажёров/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Начало_SN,Тип_тренажёра,Название_линейки,Название_модели,Фото,Примечания")] Модели_тренажёров модели_тренажёров)
        {
            if (ModelState.IsValid)
            {
                db.Модели_тренажёров.Add(модели_тренажёров);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(модели_тренажёров);
        }

        // GET: Модели_тренажёров/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Модели_тренажёров модели_тренажёров = await db.Модели_тренажёров.FindAsync(id);
            if (модели_тренажёров == null)
            {
                return HttpNotFound();
            }
            return View(модели_тренажёров);
        }

        // POST: Модели_тренажёров/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Начало_SN,Тип_тренажёра,Название_линейки,Название_модели,Фото,Примечания")] Модели_тренажёров модели_тренажёров)
        {
            if (ModelState.IsValid)
            {
                db.Entry(модели_тренажёров).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(модели_тренажёров);
        }

        // GET: Модели_тренажёров/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Модели_тренажёров модели_тренажёров = await db.Модели_тренажёров.FindAsync(id);
            if (модели_тренажёров == null)
            {
                return HttpNotFound();
            }
            return View(модели_тренажёров);
        }

        // POST: Модели_тренажёров/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            Модели_тренажёров модели_тренажёров = await db.Модели_тренажёров.FindAsync(id);
            db.Модели_тренажёров.Remove(модели_тренажёров);
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
