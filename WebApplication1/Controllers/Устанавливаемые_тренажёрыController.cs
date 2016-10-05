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
    public class Устанавливаемые_тренажёрыController : Controller
    {
        private DB_for_service_supportEntities db = new DB_for_service_supportEntities();

        // GET: Устанавливаемые_тренажёры
        public async Task<ActionResult> Index()
        {
            var устанавливаемые_тренажёры = db.Устанавливаемые_тренажёры.Include(у => у.Модели_тренажёров).Include(у => у.Установка_тренажёров);
            return View(await устанавливаемые_тренажёры.ToListAsync());
        }

        // GET: Устанавливаемые_тренажёры/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Устанавливаемые_тренажёры устанавливаемые_тренажёры = await db.Устанавливаемые_тренажёры.FindAsync(id);
            if (устанавливаемые_тренажёры == null)
            {
                return HttpNotFound();
            }
            return View(устанавливаемые_тренажёры);
        }

        // GET: Устанавливаемые_тренажёры/Create
        public ActionResult Create()
        {
            ViewBag.Начало_SN = new SelectList(db.Модели_тренажёров, "Начало_SN", "Тип_тренажёра");
            ViewBag.ID_установки = new SelectList(db.Установка_тренажёров, "ID_установки", "ID_установки");
            return View();
        }

        // POST: Устанавливаемые_тренажёры/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID_установки,Начало_SN,Количество")] Устанавливаемые_тренажёры устанавливаемые_тренажёры)
        {
            if (ModelState.IsValid)
            {
                db.Устанавливаемые_тренажёры.Add(устанавливаемые_тренажёры);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Начало_SN = new SelectList(db.Модели_тренажёров, "Начало_SN", "Тип_тренажёра", устанавливаемые_тренажёры.Начало_SN);
            ViewBag.ID_установки = new SelectList(db.Установка_тренажёров, "ID_установки", "ID_установки", устанавливаемые_тренажёры.ID_установки);
            return View(устанавливаемые_тренажёры);
        }

        // GET: Устанавливаемые_тренажёры/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Устанавливаемые_тренажёры устанавливаемые_тренажёры = await db.Устанавливаемые_тренажёры.FindAsync(id);
            if (устанавливаемые_тренажёры == null)
            {
                return HttpNotFound();
            }
            ViewBag.Начало_SN = new SelectList(db.Модели_тренажёров, "Начало_SN", "Тип_тренажёра", устанавливаемые_тренажёры.Начало_SN);
            ViewBag.ID_установки = new SelectList(db.Установка_тренажёров, "ID_установки", "ID_установки", устанавливаемые_тренажёры.ID_установки);
            return View(устанавливаемые_тренажёры);
        }

        // POST: Устанавливаемые_тренажёры/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID_установки,Начало_SN,Количество")] Устанавливаемые_тренажёры устанавливаемые_тренажёры)
        {
            if (ModelState.IsValid)
            {
                db.Entry(устанавливаемые_тренажёры).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Начало_SN = new SelectList(db.Модели_тренажёров, "Начало_SN", "Тип_тренажёра", устанавливаемые_тренажёры.Начало_SN);
            ViewBag.ID_установки = new SelectList(db.Установка_тренажёров, "ID_установки", "ID_установки", устанавливаемые_тренажёры.ID_установки);
            return View(устанавливаемые_тренажёры);
        }

        // GET: Устанавливаемые_тренажёры/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Устанавливаемые_тренажёры устанавливаемые_тренажёры = await db.Устанавливаемые_тренажёры.FindAsync(id);
            if (устанавливаемые_тренажёры == null)
            {
                return HttpNotFound();
            }
            return View(устанавливаемые_тренажёры);
        }

        // POST: Устанавливаемые_тренажёры/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Устанавливаемые_тренажёры устанавливаемые_тренажёры = await db.Устанавливаемые_тренажёры.FindAsync(id);
            db.Устанавливаемые_тренажёры.Remove(устанавливаемые_тренажёры);
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
