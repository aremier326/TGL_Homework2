namespace Homework2.Utils
{
    public class Track
    {
        public string? Title { get; init; }
        public int LapAmount { get; init; }
        public double LapDistance { get; init; }
        public double WeatherCondition { get; init; }
        public double SurfaceCondition { get; init; }

        public Track() { }

        public Track(string? title, int lapAmount, double lapDistance, double weatherCondition, double surfaceCondition)
        {
            Title = title;
            LapAmount = lapAmount;
            LapDistance = lapDistance;
            WeatherCondition = weatherCondition;
            SurfaceCondition = surfaceCondition;
        }
    }
}
