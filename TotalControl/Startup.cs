using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using TotalControl.Models;

[assembly: OwinStartupAttribute(typeof(TotalControl.Startup))]
namespace TotalControl
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRolesandUsers();
        }

        private void CreateRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            //Creating first Admin Role and creating a default Admin User
            if (!roleManager.RoleExists("Admin"))
            {
                //create Admin role
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                //Admin who will maintain the website
                var user = new ApplicationUser();
                //user.UserName = "Jane";  //not using username, email address is the username
                user.Email = "totalcontrol2019@gmail.com";

                string userPWD = "Tot@l100";

                var chkUser = UserManager.Create(user, userPWD);

                //Add default User to Admin Role
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Admin");
                }
            }

            //Creating Coordinator role
            if (!roleManager.RoleExists("Coordinator"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Coordinator";
                roleManager.Create(role);
            }

            //Creating Manager role
            if (!roleManager.RoleExists("Manager"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Manager";
                roleManager.Create(role);
            }

            //Creating Associate role
            if (!roleManager.RoleExists("Associate"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Associate";
                roleManager.Create(role);
            }
        }
    }
}
