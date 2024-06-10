namespace LifeCoach.Domain;

public class MealPlanOrder:EntityBase<Guid>
{
        public Guid UserId { get; set; }
        public User User { get; set; }
         public int Weight { get; set; }
        public int Height { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public MealPreference MealPreference { get; set; }
       public ActivityLevel ActivityLevel { get; set; }
        public Goal Goal { get; set; }
        public string Allergies { get; set; }
        public string Disorders { get; set; }
        public List<string> MealPlanResponses { get; set; } = new List<string>();
}
