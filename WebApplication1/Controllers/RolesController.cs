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
    // контроллер, который будет выполнять стандартные действия с ролями
    public class RolesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Roles
        public async Task<ActionResult> Index()
        {
            return View(await db.IdentityRoles.ToListAsync());
        }

        // GET: Roles/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationRole applicationRole = await db.IdentityRoles.FindAsync(id);
            if (applicationRole == null)
            {
                return HttpNotFound();
            }
            return View(applicationRole);
        }

        // GET: Roles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Roles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,Description")] ApplicationRole applicationRole)
        {
            if (ModelState.IsValid)
            {
                db.IdentityRoles.Add(applicationRole);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(applicationRole);
        }

        // GET: Roles/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationRole applicationRole = await db.IdentityRoles.FindAsync(id);
            if (applicationRole == null)
            {
                return HttpNotFound();
            }
            return View(applicationRole);
        }

        // POST: Roles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Description")] ApplicationRole applicationRole)
        {
            if (ModelState.IsValid)
            {
                db.Entry(applicationRole).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(applicationRole);
        }

        // GET: Roles/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationRole applicationRole = await db.IdentityRoles.FindAsync(id);
            if (applicationRole == null)
            {
                return HttpNotFound();
            }
            return View(applicationRole);
        }

        // POST: Roles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            ApplicationRole applicationRole = await db.IdentityRoles.FindAsync(id);
            db.IdentityRoles.Remove(applicationRole);
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
