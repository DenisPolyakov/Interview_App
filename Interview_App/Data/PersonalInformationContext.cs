using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Interview_App.Models
{
    public class PersonalInformationContext : DbContext
    {
        public PersonalInformationContext (DbContextOptions<PersonalInformationContext> options)
            : base(options)
        {
        }

        public DbSet<Interview_App.Models.PersonalInformation> PersonalInformation { get; set; }
    }
}
