using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MealPlan.Models
{
    public partial class Persons
    {
        public Persons()
        {
            BioData = new HashSet<BioData>();
            Logins = new HashSet<Logins>();
        }

        [Key]
        public int PersonId { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }

        public ICollection<BioData> BioData { get; set; }
        public ICollection<Logins> Logins { get; set; }
    }
}
