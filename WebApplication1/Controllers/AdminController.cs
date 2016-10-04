using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using static WebApplication1.Controllers.ManageController;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Controllers
{

    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            ViewBag.currentId = User.Identity.GetUserId();
            return View(UserManager.Users);
        }


        private ApplicationDbContext db = new ApplicationDbContext();
        //
        // GET: /Admin/Edit
        public ActionResult Edit(ManageMessageId? message, string id)
        {
            ViewBag.StatusMessage =
                message == ManageMessageId.ChangePasswordSuccess ? "Ваш пароль был успешно изменён!"
                : message == ManageMessageId.SetPasswordSuccess ? "Your password has been set."
                : message == ManageMessageId.SetTwoFactorSuccess ? "Your two-factor authentication provider has been set."
                : message == ManageMessageId.Error ? "An error has occurred."
                : message == ManageMessageId.AddPhoneSuccess ? "Your phone number was added."
                : message == ManageMessageId.RemovePhoneSuccess ? "Your phone number was removed."
                : "";


            List<string> allRoles = (from x in db.Roles select x.Name).Distinct().ToList();
            ViewBag.AllRoles = allRoles;

            ApplicationUser model = (from x in db.Users select x).First(m => m.Id == id);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Email,PasswordHash,SecurityStamp,UserName,userRoleName,secondName,patronymic,firstName")] ApplicationUser model, string SelectedRole)
        {
            if (model.Email == null)
                ModelState.AddModelError("Email", "Введите Email");




            if (ModelState.IsValid)
            {
                model.UserName = model.Email;
                model.userRoleName = SelectedRole;

                if (!UserManager.IsInRole(model.Id, SelectedRole))
                {
                    UserManager.RemoveFromRoles(model.Id, UserManager.GetRoles(model.Id).ToArray());
                    UserManager.AddToRole(model.Id, model.userRoleName);
                }

                db.Entry(model).State = EntityState.Modified;

                try
                {
                    await db.SaveChangesAsync();
                }
                catch
                {
                    ModelState.AddModelError("Email", "Пользователь с таким логином уже есть в базе");
                    List<string> allRoles1 = (from x in db.Roles select x.Name).Distinct().ToList();
                    ViewBag.AllRoles = allRoles1;

                    return View(model);
                }



                return RedirectToAction("Index");
            }

            List<string> allRoles = (from x in db.Roles select x.Name).Distinct().ToList();
            ViewBag.AllRoles = allRoles;

            return View(model);
        }


        // GET: Admin/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ApplicationUser model = (from x in db.Users select x).First(m => m.Id == id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // POST: Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            ApplicationUser model = (from x in db.Users select x).First(m => m.Id == id);
            db.Users.Remove(model);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }







        private ApplicationUserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
        }
    }
}