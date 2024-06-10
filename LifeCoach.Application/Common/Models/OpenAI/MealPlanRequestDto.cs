using LifeCoach.Domain;

namespace LifeCoach.Application;

public class MealPlanRequestDto
{

    public int Weight { get; set; }
    public int Height { get; set; }
    public int Age { get; set; }
    public Gender Gender { get; set; }
    public MealPreference MealPreference { get; set; }
    public ActivityLevel ActivityLevel { get; set; }
    public Goal Goal { get; set; }
    public string Allergies { get; set; }
    public string Disorders { get; set; }
    public static MealPlanRequestDto MapFromOrderAddCommand(OrderAddCommand orderAddCommand)
    {
        return new MealPlanRequestDto
        {
          
            Weight = orderAddCommand.Weight,
            Height = orderAddCommand.Height,
            Age = orderAddCommand.Age,
            Gender = orderAddCommand.Gender,
            MealPreference = orderAddCommand.MealPreference,
            ActivityLevel = orderAddCommand.ActivityLevel,
            Goal = orderAddCommand.Goal,
            Allergies = orderAddCommand.Allergies,
            Disorders = orderAddCommand.Disorders,
        };


}
}
