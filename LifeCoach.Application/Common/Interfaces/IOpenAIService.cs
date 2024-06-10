namespace LifeCoach.Application;

public interface IOpenAIService
{
     Task <List<string>> CreateMealPlanAsync(MealPlanRequestDto requestDto, CancellationToken cancellationToken);

}
