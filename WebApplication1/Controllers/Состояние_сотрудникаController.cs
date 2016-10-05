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
    public class Состояние_сотрудникаController : Controller
    {
        private DB_for_service_supportEntities db = new DB_for_service_supportEntities();

        // GET: Состояние_сотрудника
        public async Task<ActionResult> Index()
        {
            return View(await db.Состояние_сотрудника.ToListAsync());
        }

        // GET: Состояние_сотрудника/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Состояние_сотрудника состояние_сотрудника = await db.Состояние_сотрудника.FindAsync(id);
            if (состояние_сотрудника == null)
            {
                return HttpNotFound();
            }
            return View(состояние_сотрудника);
        }

        // GET: Состояние_сотрудника/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Состояние_сотрудника/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID_состояния,Состояние")] Состояние_сотрудника состояние_сотрудника)
        {
            if (ModelState.IsValid)
            {
                db.Состояние_сотрудника.Add(состояние_сотрудника);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(состояние_сотрудника);
        }

        // GET: Состояние_сотрудника/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Состояние_сотрудника состояние_сотрудника = await db.Состояние_сотрудника.FindAsync(id);
            if (состояние_сотрудника == null)
            {
                return HttpNotFound();
            }
            return View(состояние_сотрудника);
        }

        // POST: Состояние_сотрудника/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID_состояния,Состояние")] Состояние_сотрудника состояние_сотрудника)
        {
            if (ModelState.IsValid)
            {
                db.Entry(состояние_сотрудника).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(состояние_сотрудника);
        }

        // GET: Состояние_сотрудника/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Состояние_сотрудника состояние_сотрудника = await db.Состояние_сотрудника.FindAsync(id);
            if (состояние_сотрудника == null)
            {
                return HttpNotFound();
            }
            return View(состояние_сотрудника);
        }

        // POST: Состояние_сотрудника/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Состояние_сотрудника состояние_сотрудника = await db.Состояние_сотрудника.FindAsync(id);
            db.Состояние_сотрудника.Remove(состояние_сотрудника);
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
