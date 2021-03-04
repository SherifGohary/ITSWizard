using ITS.Wizard.DataAccess;
using ITS.Wizard.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITS.Wizard.Repositories
{
    public class ItemRepository : BaseRepository<Item, int>
    {
        public ItemRepository(WizardContext wizardContext)
            : base(wizardContext)
        {

        }
    }
}
