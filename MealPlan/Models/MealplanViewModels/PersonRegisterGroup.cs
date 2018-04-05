using System;
using System.ComponentModel.DataAnnotations;

namespace MealPlan.Models.MealplanViewModels
{
    public class PersonRegisterGroup
    {
        [DataType(DataType.Date)]
        public DateTime? RegisterDate { get; set; }

        public int PeopleCount { get; set; }
    }
}

