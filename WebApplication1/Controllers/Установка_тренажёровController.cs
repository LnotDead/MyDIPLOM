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
    public class Установка_тренажёровController : Controller
    {
        private DB_for_service_supportEntities db = new DB_for_service_supportEntities();

        // GET: Установка_тренажёров
        public async Task<ActionResult> Index()
        {
            var установка_тренажёров = db.Установка_тренажёров.Include(у => у.Клиенты).Include(у => у.Сотрудники);
            return View(await установка_тренажёров.ToListAsync());
        }

        // GET: Установка_тренажёров/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Установка_тренажёров установка_тренажёров = await db.Установка_тренажёров.FindAsync(id);
            if (установка_тренажёров == null)
            {
                return HttpNotFound();
            }
            return View(установка_тренажёров);
        }

        // GET: Установка_тренажёров/Create
        public ActionResult Create()
        {
            ViewBag.Код_клиента = new SelectList(db.Клиенты, "Код_клиента", "Тип");
            ViewBag.ID_сотрудника = new SelectList(db.Сотрудники, "ID_сотрудника", "ФИО_сотрудника");
            return View();
        }

        // POST: Установка_тренажёров/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID_установки,ID_сотрудника,Код_клиента,Дата_начала,Дата_установки")] Установка_тренажёров установка_тренажёров)
        {
            if (ModelState.IsValid)
            {
                db.Установка_тренажёров.Add(установка_тренажёров);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Код_клиента = new SelectList(db.Клиенты, "Код_клиента", "Тип", установка_тренажёров.Код_клиента);
            ViewBag.ID_сотрудника = new SelectList(db.Сотрудники, "ID_сотрудника", "ФИО_сотрудника", установка_тренажёров.ID_сотрудника);
            return View(установка_тренажёров);
        }

        // GET: Установка_тренажёров/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Установка_тренажёров установка_тренажёров = await db.Установка_тренажёров.FindAsync(id);
            if (установка_тренажёров == null)
            {
                return HttpNotFound();
            }
            ViewBag.Код_клиента = new SelectList(db.Клиенты, "Код_клиента", "Тип", установка_тренажёров.Код_клиента);
            ViewBag.ID_сотрудника = new SelectList(db.Сотрудники, "ID_сотрудника", "ФИО_сотрудника", установка_тренажёров.ID_сотрудника);
            return View(установка_тренажёров);
        }

        // POST: Установка_тренажёров/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID_установки,ID_сотрудника,Код_клиента,Дата_начала,Дата_установки")] Установка_тренажёров установка_тренажёров)
        {
            if (ModelState.IsValid)
            {
                db.Entry(установка_тренажёров).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Код_клиента = new SelectList(db.Клиенты, "Код_клиента", "Тип", установка_тренажёров.Код_клиента);
            ViewBag.ID_сотрудника = new SelectList(db.Сотрудники, "ID_сотрудника", "ФИО_сотрудника", установка_тренажёров.ID_сотрудника);
            return View(установка_тренажёров);
        }

        // GET: Установка_тренажёров/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Установка_тренажёров установка_тренажёров = await db.Установка_тренажёров.FindAsync(id);
            if (установка_тренажёров == null)
            {
                return HttpNotFound();
            }
            return View(установка_тренажёров);
        }

        // POST: Установка_тренажёров/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Установка_тренажёров установка_тренажёров = await db.Установка_тренажёров.FindAsync(id);
            db.Установка_тренажёров.Remove(установка_тренажёров);
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
