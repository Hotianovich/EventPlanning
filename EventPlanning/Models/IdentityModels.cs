using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using EventPlanning.Models.EntitiesModel;

namespace EventPlanning.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public ICollection<RegForEvent> RegForEvents { get; set; }
        public string NickName { get; set; }

        public ApplicationUser()
        {
            RegForEvents = new List<RegForEvent>();
        }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            userIdentity.AddClaim(new Claim("nick", this.NickName));
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Event> Events { get; set; }
        public DbSet<RegForEvent> RegForEvents { get; set; }
        public ApplicationDbContext()
            : base("EventPlanningDB2", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            var context = new ApplicationDbContext();
            CheckRoles(context);
            return context;
        }

        static void CheckRoles(ApplicationDbContext context)
        {

            RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            IdentityRole roleAdmin, roleUser = null;
            ApplicationUser userAdmin = null;

            userAdmin = userManager.FindByEmail("admin@mail.ru");
            if (userAdmin == null)
            {
                // создаем, если на нашли
                userAdmin = new ApplicationUser
                {
                    NickName = "admin",
                    Email = "admin@mail.ru",
                    UserName = "admin@mail.ru"
                };

                userManager.Create(userAdmin, "123456");
                // добавляем к роли admin
                userManager.AddToRole(userAdmin.Id, "admin");
            }

            roleAdmin = roleManager.FindByName("admin");
            if (roleAdmin == null)
            {
                roleAdmin = new IdentityRole { Name = "admin" };
                var result = roleManager.Create(roleAdmin);
            }

            roleUser = roleManager.FindByName("user");
            if (roleUser == null)
            {
                roleUser = new IdentityRole { Name = "user" };
                var result = roleManager.Create(roleUser);
            }
            // поиск пользователя admin@mail.ru
           
        }
    }
}