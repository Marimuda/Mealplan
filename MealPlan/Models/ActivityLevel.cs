using System;
using System.Collections.Generic;

namespace MealPlan.Models
{
    public partial class ActivityLevel
    {
        public int BioId { get; set; }
        public sbyte ActivityLevel1 { get; set; }
        public string ActivityDescription { get; set; }

        public BioData Bio { get; set; }
    }
}
