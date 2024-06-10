using LifeCoach.Application;
using OpenAI.ObjectModels;
using OpenAI.ObjectModels.RequestModels;

namespace LifeCoach.Infrastructure
{
    public class OpenAIManager : IOpenAIService
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly OpenAI.Interfaces.IOpenAIService _openAIService;

        public OpenAIManager(OpenAI.Interfaces.IOpenAIService openAIService, ICurrentUserService currentUserService)
        {
            _openAIService = openAIService;
            _currentUserService = currentUserService;
        }

        public async Task<List<string>> CreateMealPlanAsync(MealPlanRequestDto requestDto, CancellationToken cancellationToken = default)
        {
            var prompt = CreateMealPlanPrompt(requestDto);

            var chatMessages = new List<ChatMessage>
            {
                ChatMessage.FromSystem("You are a helpful assistant that generates meal plans."),
                ChatMessage.FromUser(prompt)
            };

            var completionRequest = new ChatCompletionCreateRequest
            {
                Messages = chatMessages,
                Model = Models.Gpt_3_5_Turbo,
                MaxTokens = 4000
            };

            var completionResult = await _openAIService.ChatCompletion.CreateCompletion(completionRequest, cancellationToken.ToString());

            if (completionResult.Successful)
            {
                return completionResult.Choices.Select(choice => choice.Message.Content).ToList();
            }
            else
            {
                throw new Exception($"Failed to generate meal plan: {completionResult.Error?.Message}");
            }
        }

        private string CreateMealPlanPrompt(MealPlanRequestDto requestDto)
        {
            return $"You are a doctor, dietitian, and life coach with 50 years of experience. When you include Greek yogurt in meal plans, write Turkish Yogurt instead of Greek yogurt. Only use Turkish yogurt when yogurt is needed. " +
                   $"Create a 7-day meal plan for a {requestDto.Gender} with the goal to {requestDto.Goal}. " +
                   $"Details: Weight - {requestDto.Weight} kg, Height - {requestDto.Height} cm, Age - {requestDto.Age}, " +
                   $"Meal Preference - {requestDto.MealPreference}, Activity Level - {requestDto.ActivityLevel}, " +
                   $"Allergies - {requestDto.Allergies}, Disorders - {requestDto.Disorders}. " +
                   $"Your daily calorie intake to achieve your goal is specified. Provide 3 meals (Breakfast, Lunch, Dinner) " +
                   $"for 7 days. List meals as Day 1: Breakfast, Lunch, Dinner, etc. Include grams of food for each meal. For example, 100 grams of chicken breast with 100 grams of rice.";
        }
    }
}
