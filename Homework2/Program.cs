using Homework2.Utils;

namespace Homework2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Run().Wait();
        }

        public static async Task Run()
        {
            RacingCarCollection participants = new ()
            {
                new RacingCar("Mercedes", 200, 100, new Racer("Artem Meniak")),
                new RacingCar("El Camino", 200, 100, new Racer("Jessy Pinkman")),
                new RacingCar("Pontiac", 150, 100, new Racer("Walter White")),
            };

            Track track = new Track("My Track", 5, 1343,
                Track.WeatherConditionState.Cloudy, Track.SurfaceConditionState.Exceptional);

            RacingSimulator race = new RacingSimulator(track, participants);

            await race.RunRaceAsync();
        }
    }
}