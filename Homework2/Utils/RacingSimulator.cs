using System.Threading;
using System.Threading.Tasks;
using Homework2.Utils.Abstracts;

namespace Homework2.Utils
{
    public class RacingSimulator
    {
        private Track? Track { get; }
        
        private readonly List<RacingCar>? _participants;

        public const double RaceDistanceIteration = 50;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public RacingSimulator(){}

        /// <summary>
        /// Creates an instance of RacingSimulator object
        /// </summary>
        /// <param name="track">Track instance.</param>
        /// <param name="participants">List of participants obj.</param>
        public RacingSimulator(Track track, List<RacingCar> participants)
        {
            Track = track;
            _participants = participants;
        }

        /// <summary>
        /// Method for starting the race.
        /// </summary>
        public void RunRace()
        {
            foreach (var participant in _participants)
            {
                RunParticipant(participant);
            }
            GetWinner();
        }

        /// <summary>
        /// Prints data about race winner (if he exists).
        /// </summary>
        private void GetWinner()
        {
            var winner = _participants?.Where(x => x.StillAlive()).Min();
            Console.WriteLine(winner != null
                ? $"Here is the winner! {winner}"
                : "Sorry, there is no winner!");
        }

        /// <summary>
        /// Starts race for single participant.
        /// </summary>
        /// <param name="participant"></param>
        private void RunParticipant(RacingCar participant)
        {
            participant.EngineHealthChanged += RacingCarEventListener.HealthChanged;
            participant.EngineIsAboutToBlow += RacingCarEventListener.AboutToBlow;
            participant.EngineHasDied += RacingCarEventListener.EngineHasBlown;
            
            try
            {
                double distance = Track.LapDistance * Track.LapAmount;

                while (distance >= 0 && participant.StillAlive())
                {
                    participant.Accelerate();

                    participant.TimePassed += (50 / participant.CurrentSpeed)
                                              * Track.SurfaceCondition * Track.WeatherCondition;

                    distance -= RaceDistanceIteration;
                    if (distance <= 0)
                    {
                        Console.WriteLine($"Participant {participant} finished the race!");
                    }
                }
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e);
                throw;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
