using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITS.Wizard.Entities
{
    public class Step: BaseEntity<int>
    {
        public string Name { get; set; }
        //public bool IsActive { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }
}
