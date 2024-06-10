using LifeCoach.Domain;

namespace LifeCoach.Application;

public class OrderGetAllDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
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
    public DateTimeOffset CreatedOn { get; set; }

    public static OrderGetAllDto FromOrder(MealPlanOrder order)
    {
        return new OrderGetAllDto
        {
            Id = order.Id,
            UserId = order.UserId,
            Weight = order.Weight,
            Height = order.Height,
            Age = order.Age,
            Gender = order.Gender,
            MealPreference = order.MealPreference,
            ActivityLevel = order.ActivityLevel,
            Goal = order.Goal,
            Allergies = order.Allergies,
            Disorders = order.Disorders,
            MealPlanResponses = order.MealPlanResponses,
            CreatedOn = order.CreatedOn

        };
    }

}
