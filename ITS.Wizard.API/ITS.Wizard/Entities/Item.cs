using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ITS.Wizard.Entities
{
    public class Item: BaseEntity<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int StepId { get; set; }
        [JsonIgnore]
        public virtual Step Step { get; set; }
    }
}
