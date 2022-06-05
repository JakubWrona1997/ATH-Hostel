using ATH_Hostel.Infrastructure.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATH_Hostel.Infrastructure.FakeData
{
    public static class UsersSeeder
    {
        public static async Task SeedUsersWithRoles(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            var admin = new User
            {
                Name = "Admin",
                UserName = "admin@ath-hostel.com",
                Email = "admin@ath-hostel.com",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            var manager = new User
            {               
                Name = "Manager_Hostel",
                Email = "hostelManager@ath-hostel.com",
                UserName = "hostelManager@ath-hostel.com",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            var staff = new User
            {
                Name = "Maciek_Staff",
                Email = "maciekStaff@ath-hostel.com",
                UserName = "maciekStaff@ath-hostel.com",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            var user = new User
            {
                Name = "Tomasz_Adamek",
                Email = "tomaszadamek@gmail.com",
                UserName = "tomaszadamek@gmail.com",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            if(userManager.Users.All(u => u.Id != admin.Id && u.Id != manager.Id && u.Id != staff.Id && u.Id != user.Id))
            {
                var seedAdmin = await userManager.FindByEmailAsync(admin.Email);
                var seedManager = await userManager.FindByEmailAsync(manager.Email);
                var seedStaff = await userManager.FindByEmailAsync(staff.Email);
                var seedUser = await userManager.FindByEmailAsync(user.Email);
                if(seedAdmin == null && seedManager == null && seedStaff == null && seedUser == null)
                {
                    await userManager.CreateAsync(admin, "Admin123!");
                    await userManager.CreateAsync(manager, "Manager123!");
                    await userManager.CreateAsync(staff, "Staff123!");
                    await userManager.CreateAsync(user, "User123!");

                    await userManager.AddToRoleAsync(admin, Roles.Admin.ToString());
                    await userManager.AddToRoleAsync(manager, Roles.Manager.ToString());
                    await userManager.AddToRoleAsync(staff, Roles.Staff.ToString());
                    await userManager.AddToRoleAsync(user, Roles.Client.ToString());
                }
            }
        }
    }
}
