using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATH_Hostel.Infrastructure.Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; }    
        public ICollection<Renting> Rentings { get; set; }
    }
}
