﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Proyecto1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto1.Clase
{
    public class Utilities
    {
        readonly static ApplicationDbContext db = new ApplicationDbContext();

        public static void CheckRoles(string roleName)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

            if (!roleManager.RoleExists(roleName))
            {
                roleManager.Create(new IdentityRole(roleName));
            }
        }

        internal static void CheckSuperUser()
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var userAsp = userManager.FindByName("admin@adminmail.com");

            if (userAsp == null)
            {
                CreateUserASP("admin@adminmail.com", "admin2030", "Admin");
            }
        }

        internal static void CheckClientDefault()
        {
            var Visitordb = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var userVisitor = Visitordb.FindByName("visitante@santuario.com");
            if (userVisitor == null)
            {
                CreateUserASP("visitante@santuario.com", "visitante123", "Visitor");
                userVisitor = Visitordb.FindByName("visitante@santuario.com");
                var Visitor = new Visitor
                {
                    UserId = userVisitor.Id,
                };
                db.Visitors.Add(Visitor);
                db.SaveChanges();
            }

        }

        public static void CreateUserASP(string email, string password, string rol)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var userASP = new ApplicationUser()
            {
                UserName = email,
                Email = email,
            };

            userManager.Create(userASP, password);
            userManager.AddToRole(userASP.Id, rol);
        }


        public void Dispose()
        {
            db.Dispose();
        }
    }
}