using ATH_Hostel.Infrastructure.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATH_Hostel.Infrastructure
{
    public class HostelDBContext : IdentityDbContext<User>
    {
        public HostelDBContext(DbContextOptions<HostelDBContext> options) : base(options)
        {

        }
        public DbSet<Hostel> Hostels { get; set; }
        public override DbSet<User> Users { get; set; }
        public DbSet<Renting> Rentings { get; set; }
        public DbSet<Room> Rooms { get; set; }
    }
}
