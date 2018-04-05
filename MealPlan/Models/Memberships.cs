using System;
using System.Collections.Generic;

namespace MealPlan.Models
{
    public partial class Memberships
    {
        public int MembershipId { get; set; }
        public string EmailAdress { get; set; }
        public DateTimeOffset CreationDate { get; set; }
        public DateTime LastLogin { get; set; }
        public string PasswordQuestion { get; set; }
        public string PasswordAnswer { get; set; }
        public sbyte FailedAttempts { get; set; }
        public int LoginId { get; set; }
        public int AccountId { get; set; }

        public Account Account { get; set; }
        public Logins Login { get; set; }
    }
}
