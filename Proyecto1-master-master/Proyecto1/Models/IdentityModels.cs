using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Proyecto1.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "Nombre Completo")]
        [MaxLength(50)]
        public string Nombre { get; set; }
        [Display(Name = "Apellido Materno")]
        [MaxLength(50)]
        public string ApM { get; set; }
        [Display(Name = "Apellido Paterno")]
        [MaxLength(50)]
        public string ApP { get; set; }
        [Display(Name = "Dirección")]
        [MaxLength(50)]
        public string Direccion { get; set; }
        [Display(Name = "Número de celular")]
        [MaxLength(20)]
        public string Celular { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public DbSet<Visitor> Visitors { get; set; }

        public System.Data.Entity.DbSet<Proyecto1.Models.biodiversity> biodiversities { get; set; }

        public System.Data.Entity.DbSet<Proyecto1.Models.visit> visits { get; set; }

        public System.Data.Entity.DbSet<Proyecto1.Models.sanctuary> sanctuaries { get; set; }

        public System.Data.Entity.DbSet<Proyecto1.Models.visit_shrine> visit_shrine { get; set; }
    }
}