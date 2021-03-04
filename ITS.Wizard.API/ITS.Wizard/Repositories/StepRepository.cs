using ITS.Wizard.DataAccess;
using ITS.Wizard.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITS.Wizard.Repositories
{
    public class StepRepository : BaseRepository<Step, int>
    {
        public StepRepository(WizardContext wizardContext)
            :base(wizardContext)
        {

        }
    }
}
