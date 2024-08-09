namespace HealthTrak.Server.Models;

public class Nutrition
{
    public List<Food>? foods { get; set; } = null;
    public int totalCalories { get; set; }
    public int targetCalories { get; set; } = 2000;
}

