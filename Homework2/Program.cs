using Homework2.Utils;

namespace Homework2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<RacingCar> participants = new List<RacingCar>()
            {
                new RacingCar("Mercedes", 150, 100, new Racer("Artem Meniak"))
            };

            Track track = new Track("My Track", 2, 300, 
                Track.WeatherConditionState.Cloudy, Track.SurfaceConditionState.Exceptional);

            RacingSimulator race = new RacingSimulator(track, participants);

            race.RunRace();
            

        }
    }
}