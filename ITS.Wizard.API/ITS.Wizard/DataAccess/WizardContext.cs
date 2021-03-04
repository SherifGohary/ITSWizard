using ITS.Wizard.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITS.Wizard.DataAccess
{
    public class WizardContext: DbContext
    {
        public WizardContext(DbContextOptions<WizardContext> options)
            :base(options)
        {

        }

        public DbSet<Step> Steps { get; set; }
        public DbSet<Item> Items { get; set; }
    }
}
