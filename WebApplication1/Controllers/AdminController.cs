using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{

    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {

            return View(UserManager.Users);
        }

        private ApplicationUserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
        }

        /////////////////////////////////////////////

        private ApplicationDbContext db = new ApplicationDbContext();
        //
        // GET: /Manage/Index
        //public async Task<ActionResult> Index(ManageMessageId? message)
        public ActionResult Edit(ManageMessageId? message, string id)
        {
            ViewBag.StatusMessage =
                message == ManageMessageId.ChangePasswordSuccess ? "Пароль был успешно изменён!"
                : message == ManageMessageId.SetPasswordSuccess ? "Your password has been set."
                : message == ManageMessageId.SetTwoFactorSuccess ? "Your two-factor authentication provider has been set."
                : message == ManageMessageId.Error ? "An error has occurred."
                : "";


            List<string> allRoles = (from x in db.Roles select x.Name).Distinct().ToList();
            ViewBag.AllRoles = allRoles;
            //string currentId = User.Identity.GetUserId();
            ApplicationUser model = (from x in db.Users select x).First(m => m.Id == id);

            return View(model);
        }

        // POST: Клиенты/Index/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<ActionResult> Index([Bind(Include = "Id,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName,userRoleName,secondName,patronymic,firstName")] ApplicationUser model, string SelectedRole)
        public async Task<ActionResult> Edit([Bind(Include = "Id,Email,PasswordHash,SecurityStamp,UserName,userRoleName,secondName,patronymic,firstName")] ApplicationUser model, string SelectedRole)
        {
            model.UserName = model.Email;
            model.userRoleName = SelectedRole;


            if (ModelState.IsValid)
            {
                if (!UserManager.IsInRole(model.Id, SelectedRole))
                {
                    UserManager.RemoveFromRoles(model.Id, UserManager.GetRoles(model.Id).ToArray());
                    UserManager.AddToRole(model.Id, model.userRoleName);
                }

                db.Entry(model).State = EntityState.Modified;

                await db.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }





        public enum ManageMessageId
        {
            ChangePasswordSuccess,
            SetTwoFactorSuccess,
            SetPasswordSuccess,
            RemoveLoginSuccess,
            Error
        }
    }
}