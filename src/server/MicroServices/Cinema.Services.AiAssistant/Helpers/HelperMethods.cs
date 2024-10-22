namespace Cinema.Services.AiAssistant.Helpers
{
    public static class HelperMethods
    {
        public static string GetCurrentLocation()
        {
            return "Türkiyenin en güzel şehri olan Sakaryadasın.";
        }

        public static string GetCurrentWeather(string location, string unit = "celsius")
        {
            return $"109 {unit} kar yağışlı.";
        }
    }
}
