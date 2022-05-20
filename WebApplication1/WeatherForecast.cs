namespace WebApplication1
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }
    }

    public class Kaffeemaschine
    {
        

        public double wasser { get;  set; }

        public double bohnen { get;  set; }

        public double gesamtMengeKaffeProduziert { get;  set; }

        private static double maxWasser => 2.5;

        private static double maxBohnen => 2.5;

    }
}