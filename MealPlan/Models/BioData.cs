using System;
using System.Collections.Generic;

namespace MealPlan.Models
{
    public partial class BioData
    {
        public int BioId { get; set; }
        public sbyte Weight { get; set; }
        public sbyte Height { get; set; }
        public string Gender { get; set; }
        public DateTime Birthday { get; set; }
        public int? PersonId { get; set; }

        public Persons Person { get; set; }
        public ActivityLevel ActivityLevel { get; set; }
    }
}
