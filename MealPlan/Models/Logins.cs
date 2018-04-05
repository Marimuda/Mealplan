using System;
using System.Collections.Generic;

namespace MealPlan.Models
{
    public partial class Logins
    {
        public Logins()
        {
            Memberships = new HashSet<Memberships>();
        }

        public int AccountId { get; set; }
        public string Username { get; set; }
        public string PasswordSalt { get; set; }
        public string PasswordHash { get; set; }
        public bool? IsActivated { get; set; }
        public int PersonId { get; set; }

        public Persons Person { get; set; }
        public ICollection<Memberships> Memberships { get; set; }
    }
}
