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
using System.Data.Entity.Validation;

namespace WebApplication1.Controllers
{
    public class КлиентыController : Controller
    {
        private DB_for_service_supportEntities db = new DB_for_service_supportEntities();

        // GET: Клиенты
        public async Task<ActionResult> Index()
        {


            return View(await db.Клиенты.ToListAsync());
        }

        // GET: Клиенты/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Клиенты клиенты = await db.Клиенты.FindAsync(id);
            if (клиенты == null)
            {
                return HttpNotFound();
            }
            return View(клиенты);
        }

        // GET: Клиенты/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Клиенты/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Код_клиента,Тип,ФИО_Название_клуба,Паспортные_данные_Реквизиты,Город,Адрес,Основной_контакт,Дополнительные_контакты,Примечания")] Клиенты клиенты)
        {
            if (ModelState.IsValid)
            {



                db.Клиенты.Add(клиенты);



                try
                {
                    await db.SaveChangesAsync();
            }
                catch (DbEntityValidationException ex)
            {
                foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
                {
                    Response.Write("Object: " + validationError.Entry.Entity.ToString());
                    Response.Write("                ");
                    foreach (DbValidationError err in validationError.ValidationErrors)
                    {
                        Response.Write(err.ErrorMessage + "           ");
                    }
                }
            }




            return RedirectToAction("Index");
            }

            return View(клиенты);
        }

        // GET: Клиенты/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Клиенты клиенты = await db.Клиенты.FindAsync(id);
            if (клиенты == null)
            {
                return HttpNotFound();
            }
            return View(клиенты);
        }

        // POST: Клиенты/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Код_клиента,Тип,ФИО_Название_клуба,Паспортные_данные_Реквизиты,Город,Адрес,Основной_контакт,Дополнительные_контакты,Примечания")] Клиенты клиенты)
        {
            if (ModelState.IsValid)
            {
                db.Entry(клиенты).State = EntityState.Modified;



                //try
                //{
                    await db.SaveChangesAsync();
                //}
                //catch (DbEntityValidationException ex)
                //{
                //    foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
                //    {
                //        Response.Write("Object: " + validationError.Entry.Entity.ToString());
                //        Response.Write("                ");
                //        foreach (DbValidationError err in validationError.ValidationErrors)
                //        {
                //            Response.Write(err.ErrorMessage + "           ");
                //        }
                //    }
                //}






                return RedirectToAction("Index");
            }
            return View(клиенты);
        }

        // GET: Клиенты/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Клиенты клиенты = await db.Клиенты.FindAsync(id);
            if (клиенты == null)
            {
                return HttpNotFound();
            }
            return View(клиенты);
        }

        // POST: Клиенты/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Клиенты клиенты = await db.Клиенты.FindAsync(id);
            db.Клиенты.Remove(клиенты);
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
