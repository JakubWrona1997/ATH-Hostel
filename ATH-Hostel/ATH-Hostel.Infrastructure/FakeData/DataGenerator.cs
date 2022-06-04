using ATH_Hostel.Infrastructure.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATH_Hostel.Infrastructure.FakeData
{
    public static class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new HostelDBContext(
                serviceProvider.GetRequiredService<DbContextOptions<HostelDBContext>>()))
            {
                context.Hostels.AddRange(
                    new Hostel
                    {
                        Id = 1,
                        Name = "Bielsko Hostel",
                        City = "Bielsko-Biała",
                        Address = "ul. Willowa 52",
                        Description = "Main Hostel"
                    },
                    new Hostel
                    {
                        Id = 2,
                        Name = "Katowice Hostel",
                        City = "Katowice",
                        Address = "ul. Polska 12",
                        Description = "Second hostel"
                    }
                    );
                context.Rooms.AddRange(
                    new Room
                    {
                        Id = 1,
                        Name = "Casual room 1",
                        Description = "Room for one person",
                        PriceForNight = 50,
                        BedsAmount = 1,
                        HostelId = 1,
                        RoomType = Enums.RoomType.Standard
                    }
                    );
                context.Rentings.AddRange(
                    new Renting
                    {
                        Id = 1,
                        CreationDate = DateTimeOffset.UtcNow,
                        BeginDate = new DateTimeOffset(2022, 04, 12, 12, 32, 00, TimeSpan.Zero),
                        EndDate = new DateTimeOffset(2022, 04, 15, 12, 32, 00, TimeSpan.Zero),
                        RoomId = 1,
                        UserId = Guid.NewGuid().ToString()
                    }
                    );
                context.Users.AddRange(
                    new User
                    {
                        Id = Guid.NewGuid().ToString(),
                        Name = "Jakub",
                        Email = "jakub@gmail.com",
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
