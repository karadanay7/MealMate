namespace LifeCoach.Domain
{
    public enum MealPreference
    {
        None = 0,                        // No specific meal preference
        Balanced = 1,                    // General balanced diet
        HighProtein = 2,                 // Diet high in protein
        LowCarb = 3,                     // Diet low in carbohydrates
        LowFat = 4,                      // Diet low in fats
        Keto = 5,                        // Ketogenic diet, high in fats, very low in carbs
        Vegan = 6,                       // Diet excluding all animal products
        Vegetarian = 7,                  // Diet excluding meat and fish
        Pescatarian = 8,                 // Vegetarian diet that includes fish
        Mediterranean = 9,               // Diet based on Mediterranean eating patterns
        IntermittentFasting = 10,        // Eating pattern with periods of fasting
        Paleo = 11,                      // Diet based on ancient eating patterns (Paleolithic)
        LowSodium = 12,                  // Diet low in sodium
        LowSugar = 13,                   // Diet low in sugar
        HighFiber = 14,                  // Diet high in fiber
        DiabeticFriendly = 15,           // Diet for managing diabetes
        HeartHealthy = 16,               // Diet focusing on cardiovascular health
        AntiInflammatory = 17,           // Diet aiming to reduce inflammation
        Flexitarian = 18                 // Semi-vegetarian diet with occasional meat intake
    }
}
