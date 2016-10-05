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
    [Authorize(Roles = "Admin, Engineer")]
    public class Склад_запасных_деталейController : Controller
    {
        private DB_for_service_supportEntities db = new DB_for_service_supportEntities();

        // GET: Склад_запасных_деталей
        public async Task<ActionResult> Index()
        {
            return View(await db.Склад_запасных_деталей.ToListAsync());
        }

        // GET: Склад_запасных_деталей/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Склад_запасных_деталей склад_запасных_деталей = await db.Склад_запасных_деталей.FindAsync(id);
            if (склад_запасных_деталей == null)
            {
                return HttpNotFound();
            }
            return View(склад_запасных_деталей);
        }

        // GET: Склад_запасных_деталей/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Склад_запасных_деталей/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Код_детали,Количество,Примечания,Плановый_запас")] Склад_запасных_деталей склад_запасных_деталей)
        {
            if ((from x in db.Склад_запасных_деталей select x).Any(x => x.Код_детали == склад_запасных_деталей.Код_детали))
            {
                ModelState.AddModelError("Код_детали", "В базе уже есть запасная деталь с таким кодом.");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    db.Склад_запасных_деталей.Add(склад_запасных_деталей);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }

            return View(склад_запасных_деталей);
        }

        // GET: Склад_запасных_деталей/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Склад_запасных_деталей склад_запасных_деталей = await db.Склад_запасных_деталей.FindAsync(id);
            if (склад_запасных_деталей == null)
            {
                return HttpNotFound();
            }
            return View(склад_запасных_деталей);
        }

        // POST: Склад_запасных_деталей/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Код_детали,Количество,Примечания,Плановый_запас")] Склад_запасных_деталей склад_запасных_деталей)
        {
            if (ModelState.IsValid)
            {
                db.Entry(склад_запасных_деталей).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(склад_запасных_деталей);
        }

        // GET: Склад_запасных_деталей/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Склад_запасных_деталей склад_запасных_деталей = await db.Склад_запасных_деталей.FindAsync(id);
            if (склад_запасных_деталей == null)
            {
                return HttpNotFound();
            }
            return View(склад_запасных_деталей);
        }

        // POST: Склад_запасных_деталей/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            Склад_запасных_деталей склад_запасных_деталей = await db.Склад_запасных_деталей.FindAsync(id);

            try
            {
                db.Склад_запасных_деталей.Remove(склад_запасных_деталей);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError("ErrorMessage", "Данную запись нельзя удалить, т.к. на неё имеются ссылки в других таблицах. Удалите ссылки в других таблицах и повторите удаление записи");
                return View(склад_запасных_деталей);
            }
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
