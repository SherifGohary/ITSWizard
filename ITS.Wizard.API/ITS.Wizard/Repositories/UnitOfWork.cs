using ITS.Wizard.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITS.Wizard.Repositories
{
    public class UnitOfWork
    {
        private WizardContext _context;

        public UnitOfWork(WizardContext context)
        {
            this._context = context;
        }

        public void Commit()
        {
            this._context.SaveChanges();
        }
    }
}
