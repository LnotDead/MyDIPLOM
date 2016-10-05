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
    public class Установленные_деталиController : Controller
    {
        private DB_for_service_supportEntities db = new DB_for_service_supportEntities();

        // GET: Установленные_детали
        public async Task<ActionResult> Index()
        {
            var установленные_детали = db.Установленные_детали.Include(у => у.Подходящие_запасные_детали).Include(у => у.Тренажёры);
            return View(await установленные_детали.ToListAsync());
        }

        // GET: Установленные_детали/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Установленные_детали установленные_детали = await db.Установленные_детали.FindAsync(id);
            if (установленные_детали == null)
            {
                return HttpNotFound();
            }
            return View(установленные_детали);
        }

        // GET: Установленные_детали/Create
        public ActionResult Create()
        {
            ViewBag.Код_детали = new SelectList(db.Подходящие_запасные_детали, "Код_детали", "Код_детали");
            ViewBag.Начало_SN = new SelectList(db.Тренажёры, "Начало_SN", "Примечания");
            return View();
        }

        // POST: Установленные_детали/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID_установки_детали,Начало_SN,Конец_SN,Код_детали,Количество,Дата_установки,Примечания")] Установленные_детали установленные_детали)
        {
            if (ModelState.IsValid)
            {
                db.Установленные_детали.Add(установленные_детали);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Код_детали = new SelectList(db.Подходящие_запасные_детали, "Код_детали", "Код_детали", установленные_детали.Код_детали);
            ViewBag.Начало_SN = new SelectList(db.Тренажёры, "Начало_SN", "Примечания", установленные_детали.Начало_SN);
            return View(установленные_детали);
        }

        // GET: Установленные_детали/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Установленные_детали установленные_детали = await db.Установленные_детали.FindAsync(id);
            if (установленные_детали == null)
            {
                return HttpNotFound();
            }
            ViewBag.Код_детали = new SelectList(db.Подходящие_запасные_детали, "Код_детали", "Код_детали", установленные_детали.Код_детали);
            ViewBag.Начало_SN = new SelectList(db.Тренажёры, "Начало_SN", "Примечания", установленные_детали.Начало_SN);
            return View(установленные_детали);
        }

        // POST: Установленные_детали/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID_установки_детали,Начало_SN,Конец_SN,Код_детали,Количество,Дата_установки,Примечания")] Установленные_детали установленные_детали)
        {
            if (ModelState.IsValid)
            {
                db.Entry(установленные_детали).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Код_детали = new SelectList(db.Подходящие_запасные_детали, "Код_детали", "Код_детали", установленные_детали.Код_детали);
            ViewBag.Начало_SN = new SelectList(db.Тренажёры, "Начало_SN", "Примечания", установленные_детали.Начало_SN);
            return View(установленные_детали);
        }

        // GET: Установленные_детали/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Установленные_детали установленные_детали = await db.Установленные_детали.FindAsync(id);
            if (установленные_детали == null)
            {
                return HttpNotFound();
            }
            return View(установленные_детали);
        }

        // POST: Установленные_детали/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Установленные_детали установленные_детали = await db.Установленные_детали.FindAsync(id);
            db.Установленные_детали.Remove(установленные_детали);
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
