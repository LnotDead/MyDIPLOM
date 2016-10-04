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
        public async Task<ActionResult> Edit([Bind(Include = "Начало_SN,Тип_тренажёра,Название_линейки,Название_модели,Примечания, ImageData, ImageMimeType")] Модели_тренажёров модели_тренажёров, HttpPostedFileBase image, string returnUrl)
        {

            if (ModelState.IsValid)
            {

                if (image != null)
                {
                    if (image.ContentLength > 2097152) // 2 Мб
                    {
                        ViewBag.Pic = "Вы пытались загрузить картинку более 2 Мб";
                        //return Redirect(returnUrl);

                        return View(модели_тренажёров);
                    }

                    модели_тренажёров.ImageMimeType = image.ContentType;
                    модели_тренажёров.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(модели_тренажёров.ImageData, 0, image.ContentLength);
                }

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

            try
            {
                db.Модели_тренажёров.Remove(модели_тренажёров);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError("ErrorMessage", "Данную запись нельзя удалить, т.к. на неё имеются ссылки в других таблицах. Удалите ссылки в других таблицах и повторите удаление записи");
                return View(модели_тренажёров);
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



        //Этот метод пытается найти модель тренажёра, которая соответствует указанному
        //в параметре началу SN.Он возвращает класс FileContentResult, когда мы
        //хотим вернуть файл браузеру клиента, и экземпляры создаются
        //с помощью метода File базового класса контроллера.

        public FileContentResult GetImage(string Начало_SN)
        {
            Модели_тренажёров модели_тренажёров = db.Модели_тренажёров.FirstOrDefault(p => p.Начало_SN == Начало_SN);

            if (модели_тренажёров != null)
            { return File(модели_тренажёров.ImageData, модели_тренажёров.ImageMimeType); }
            else
            { return null; }
        }


    }
}
