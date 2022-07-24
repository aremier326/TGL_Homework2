namespace Homework2.Utils
{
    /// <summary>
    /// Represents racing track instance.
    /// </summary>
    public class Track
    {
        #region Props

        public string? Title { get; init; }
        public int LapAmount { get; init; }
        public double LapDistance { get; init; }
        public double WeatherCondition { get; init; }
        public double SurfaceCondition { get; init; }

        #endregion


        /// <summary>
        /// Struct for choosing weather coefficient when calculating racer time.
        /// </summary>
        public struct WeatherConditionState
        {
            public const double Sunny = 1.0;
            public const double Rainy = 1.25;
            public const double Stormy = 1.7;
            public const double Foggy = 1.1;
            public const double Windy = 1.2;
            public const double Cloudy = 1.0;
        }

        /// <summary>
        /// Struct for choosing weather coefficient when calculating racer time.
        /// </summary>
        public struct SurfaceConditionState
        {
            public const double Exceptional = 1.0;
            public const double Ordinary = 1.15;
            public const double Bad = 1.5;
            public const double Terrible = 1.7;
        }

        public Track() { }

        /// <summary>
        /// Creates Track instance.
        /// </summary>
        /// <param name="title">Track title.</param>
        /// <param name="lapAmount">Amount of laps.</param>
        /// <param name="lapDistance">Distance of single lap.</param>
        /// <param name="weatherCondition">Weather condition coefficient.</param>
        /// <param name="surfaceCondition">Surface condition coefficient.</param>
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
