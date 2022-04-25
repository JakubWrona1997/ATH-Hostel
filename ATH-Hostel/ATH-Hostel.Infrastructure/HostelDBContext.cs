using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATH_Hostel.Infrastructure
{
    public class HostelDBContext : DbContext
    {
        public HostelDBContext(DbContextOptions<HostelDBContext> options) : base(options)
        {

        }
    }
}
