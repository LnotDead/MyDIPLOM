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
    public class ТренажёрыController : Controller
    {
        private DB_for_service_supportEntities db = new DB_for_service_supportEntities();

        // GET: Тренажёры
        public async Task<ActionResult> Index()
        {
            //var тренажёры = db.Тренажёры.Include(т => т.Клиенты).Include(т => т.Модели_тренажёров).Include(т => т.Установка_тренажёров);
            //return View(await тренажёры.ToListAsync());

            return View(await db.Тренажёры.ToListAsync());
        }

        // GET: Тренажёры/Details/5
        public async Task<ActionResult> Details(string part1, string part2)
        {
            if (part1 == null | part2 == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Тренажёры тренажёры = await db.Тренажёры.FindAsync(part1, part2);
            if (тренажёры == null)
            {
                return HttpNotFound();
            }
            return View(тренажёры);
        }

        // GET: Тренажёры/Create
        public ActionResult Create()
        {

            ViewBag.Код_клиента = new SelectList(db.Клиенты.OrderBy(t => t.ФИО_Название_клуба), "Код_клиента", "ФИО_Название_клуба");
            ViewBag.Начало_SN = new SelectList(db.Модели_тренажёров.OrderBy(t => t.Начало_SN), "Начало_SN", "Начало_SN");
            ViewBag.ID_установки = new SelectList(db.Установка_тренажёров, "ID_установки", "ID_установки");
            return View();
        }

        // POST: Тренажёры/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Начало_SN,Конец_SN,Код_клиента,Основная_гарантия,Примечания,ID_установки")] Тренажёры тренажёры)
        {
            if ((from x in db.Тренажёры select x).Any(x => x.Начало_SN + x.Конец_SN == тренажёры.Начало_SN + тренажёры.Конец_SN))
            {
                ModelState.AddModelError("Конец_SN", "В базе уже есть тренажёр с таким SN.");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    тренажёры.ID_установки = null;

                    db.Тренажёры.Add(тренажёры);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }

            ViewBag.Код_клиента = new SelectList(db.Клиенты, "Код_клиента", "ФИО_Название_клуба", тренажёры.Код_клиента);
            ViewBag.Начало_SN = new SelectList(db.Модели_тренажёров, "Начало_SN", "Начало_SN", тренажёры.Начало_SN);
            ViewBag.ID_установки = new SelectList(db.Установка_тренажёров, "ID_установки", "ID_установки", тренажёры.ID_установки);
            return View(тренажёры);
        } 

        // GET: Тренажёры/Edit/5
        public async Task<ActionResult> Edit(string part1, string part2)
        {
            if (part1 == null | part2 == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Тренажёры тренажёры = await db.Тренажёры.FindAsync(part1, part2);
            if (тренажёры == null)
            {
                return HttpNotFound();
            }
            //ViewBag.Код_клиента = new SelectList(db.Клиенты, "Код_клиента", "ФИО_Название_клуба", тренажёры.Код_клиента);
            ViewBag.Код_клиента = new SelectList(db.Клиенты.OrderBy(t => t.ФИО_Название_клуба), "Код_клиента", "ФИО_Название_клуба", тренажёры.Код_клиента);
            ViewBag.Начало_SN = new SelectList(db.Модели_тренажёров, "Начало_SN", "Тип_тренажёра", тренажёры.Начало_SN);
            ViewBag.ID_установки = new SelectList(db.Установка_тренажёров, "ID_установки", "ID_установки", тренажёры.ID_установки);
            return View(тренажёры);
        }

        // POST: Тренажёры/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Начало_SN,Конец_SN,Код_клиента,Основная_гарантия,Примечания,ID_установки")] Тренажёры тренажёры)
        {
            if (ModelState.IsValid)
            {
                db.Entry(тренажёры).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Код_клиента = new SelectList(db.Клиенты, "Код_клиента", "ФИО_Название_клуба", тренажёры.Код_клиента);
            ViewBag.Начало_SN = new SelectList(db.Модели_тренажёров, "Начало_SN", "Тип_тренажёра", тренажёры.Начало_SN);
            //ViewBag.ID_установки = new SelectList(db.Установка_тренажёров, "ID_установки", "ID_установки", тренажёры.ID_установки);
            return View(тренажёры);
        }

        // GET: Тренажёры/Delete/5
        public async Task<ActionResult> Delete(string part1, string part2)
        {
            if (part1 == null | part2 == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Тренажёры тренажёры = await db.Тренажёры.FindAsync(part1, part2);
            if (тренажёры == null)
            {
                return HttpNotFound();
            }
            return View(тренажёры);
        }

        // POST: Тренажёры/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string part1, string part2)
        {
            Тренажёры тренажёры = await db.Тренажёры.FindAsync(part1, part2);
            db.Тренажёры.Remove(тренажёры);
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
