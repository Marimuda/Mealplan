using System;
using System.Collections.Generic;

namespace MealPlan.Models
{
    public partial class ActivityLevels
    {
        public enum Level
        {
            A, B, C, D, E
        }
        public int BioId { get; set; }
        public Level? ActivityLevel { get; set; }
        public string ActivityDescription { get; set; }

        public BioData BioData { get; set; }
    }
}
