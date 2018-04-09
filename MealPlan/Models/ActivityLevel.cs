namespace MealPlan.Models
{
    public partial class ActivityLevel
    {
        public int BioId { get; set; }
        public sbyte Activity { get; set; }
        public string ActivityDescription { get; set; }

        public BioData Bio { get; set; }
    }
}
