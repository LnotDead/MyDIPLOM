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
    [Authorize(Roles = "Admin")]
    public class СотрудникиController : Controller
    {
        private DB_for_service_supportEntities db = new DB_for_service_supportEntities();

        // GET: Сотрудники
        public async Task<ActionResult> Index()
        {
            var сотрудники = db.Сотрудники.Include(с => с.Состояние_сотрудника);
            return View(await сотрудники.ToListAsync());
        }

        // GET: Сотрудники/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Сотрудники сотрудники = await db.Сотрудники.FindAsync(id);
            if (сотрудники == null)
            {
                return HttpNotFound();
            }
            return View(сотрудники);
        }

        // GET: Сотрудники/Create
        public ActionResult Create()
        {
            ViewBag.ID_состояния = new SelectList(db.Состояние_сотрудника, "ID_состояния", "Состояние");
            return View();
        }

        // POST: Сотрудники/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID_сотрудника,ФИО_сотрудника,Должность,Номер_телефона,Логин,Пароль,ID_состояния,Примечания")] Сотрудники сотрудники)
        {
            if (ModelState.IsValid)
            {
                db.Сотрудники.Add(сотрудники);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ID_состояния = new SelectList(db.Состояние_сотрудника, "ID_состояния", "Состояние", сотрудники.ID_состояния);
            return View(сотрудники);
        }

        // GET: Сотрудники/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Сотрудники сотрудники = await db.Сотрудники.FindAsync(id);
            if (сотрудники == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_состояния = new SelectList(db.Состояние_сотрудника, "ID_состояния", "Состояние", сотрудники.ID_состояния);
            return View(сотрудники);
        }

        // POST: Сотрудники/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID_сотрудника,ФИО_сотрудника,Должность,Номер_телефона,Логин,Пароль,ID_состояния,Примечания")] Сотрудники сотрудники)
        {
            if (ModelState.IsValid)
            {
                db.Entry(сотрудники).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ID_состояния = new SelectList(db.Состояние_сотрудника, "ID_состояния", "Состояние", сотрудники.ID_состояния);
            return View(сотрудники);
        }

        // GET: Сотрудники/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Сотрудники сотрудники = await db.Сотрудники.FindAsync(id);
            if (сотрудники == null)
            {
                return HttpNotFound();
            }
            return View(сотрудники);
        }

        // POST: Сотрудники/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Сотрудники сотрудники = await db.Сотрудники.FindAsync(id);
            db.Сотрудники.Remove(сотрудники);
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
