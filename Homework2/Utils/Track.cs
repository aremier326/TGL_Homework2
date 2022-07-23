﻿namespace Homework2.Utils
{
    /// <summary>
    /// Represents racing track.
    /// </summary>
    public class Track
    {
        public string? Title { get; init; }
        public int LapAmount { get; init; }
        public double LapDistance { get; init; }
        public double WeatherCondition { get; init; }
        public double SurfaceCondition { get; init; }

        /// <summary>
        /// Struct for choosing weather coefficient when calculating racer score.
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
        /// Struct for choosing weather coefficient when calculating racer score.
        /// </summary>
        public struct SurfaceConditionState
        {
            public const double Exceptional = 1.0;
            public const double Ordinary = 1.15;
            public const double Bad = 1.5;
            public const double Terrible = 1.7;
        }

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
