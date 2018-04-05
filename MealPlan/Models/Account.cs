using System;
using System.Collections.Generic;

namespace MealPlan.Models
{
    public partial class Account
    {
        public Account()
        {
            Memberships = new HashSet<Memberships>();
            Recipes = new HashSet<Recipes>();
        }

        public int AccountId { get; set; }
        public string DisplayedName { get; set; }
        public sbyte Role { get; set; }

        public ICollection<Memberships> Memberships { get; set; }
        public ICollection<Recipes> Recipes { get; set; }
    }
}
