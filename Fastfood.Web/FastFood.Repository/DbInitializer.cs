using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FastFood.Repository
{
	public class DbInitializer:IDbInitializer
	{
		private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityRole> _userManager;
        private readonly ApplicationDbContext _context;

        public DbInitializer(RoleManager<IdentityRole> roleManager, UserManager<IdentityRole> userManager, ApplicationDbContext context)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _context = context;
        }

        public void Initialize()
		{
            try
            {
                if (_context.Database.GetPendingMigrations().Count() > 0)
                {
                    _context.Database.Migrate();
                }
            }
            catch(Exception)
            {
                throw;

            }

            if (_context.Roles.Any(x => x.Name == "Manager")) return;
            _roleManager.CreateAsync(new IdentityRole("Manager")).
                GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole("Admin")).
                GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole("Customer")).
                GetAwaiter().GetResult();

            var user = new ApplicationUser()
            {
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                nameof = "Admin",
                City = "Orlando",
                Address = "1404 wood vioolet dr",
                PostalCode = "32824",
            };
            _userManager.CreateAsync(user,"Admin@123").
                GetAwaiter().GetResult();
            _userManager.AddToRoleAsync(user, "Admin");
           
        }
	}
}

