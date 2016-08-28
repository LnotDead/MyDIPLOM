using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace WebApplication1.Models
{
    // менеджер ролей на основе стандартного RoleManager
    public class ApplicationRoleManager: RoleManager<ApplicationRole>
    {
        public ApplicationRoleManager(RoleStore<ApplicationRole> store)
            : base(store)
        { }

        // Метод Create позволит классу приложения OWIN создавать экземпляры
        // менеджера ролей для обработки каждого запроса, где идет обращение
        // к хранилищу ролей RoleStore.
        public static ApplicationRoleManager Create(IdentityFactoryOptions<ApplicationRoleManager> options,
                                                IOwinContext context)
        {
            return new ApplicationRoleManager
                (new RoleStore<ApplicationRole>(context.Get<ApplicationDbContext>()));
        }
    }
}