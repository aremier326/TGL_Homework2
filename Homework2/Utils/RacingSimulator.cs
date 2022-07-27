using System.Threading;
using System.Threading.Tasks;
using Homework2.Utils.Abstracts;

namespace Homework2.Utils
{
    public class RacingSimulator
    {
        private Track? Track { get; }
        
        private readonly RacingCarCollection _participants;

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
        public RacingSimulator(Track track, RacingCarCollection participants)
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
        /// Async method for starting the race.
        /// </summary>
        public async Task RunRaceAsync()
        {
            var tasks = new List<Task>();

            Console.WriteLine("\n-------RACE HAS STARTED!-------\n" + 
                              $"-------LAP DISTANCE {Track.LapDistance}-------\n" +
                              $"-------TOTAL LAPS {Track.LapAmount}-------\n");

            foreach (var participant in _participants)
            {
                tasks.Add(Task.Run(() => RunParticipantAsync(participant)));
            }

            await Task.WhenAll(tasks);

            Console.WriteLine("\n-------RACE FINISHED!-------\n");

            GetWinner();
        }


        /// <summary>
        /// Prints data about race winner (if he exists).
        /// </summary>
        private void GetWinner()
        {
            var winner = _participants?.Where(x => x.StillAlive()).Min();
            Console.WriteLine(winner != null
                ? $"\n-------Here is the winner! {winner}-------\n"
                : "\n-------Sorry, there is no winner!-------\n");
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
            participant.SpeedChanged += RacingCarEventListener.SpeedChanged;

            try
            {
                double distance = Track.LapDistance * Track.LapAmount;

                Console.WriteLine(participant + " started the race!\n");
                while (distance >= 0 && participant.StillAlive())
                {
                    participant.Accelerate();

                    participant.TimePassed += (RaceDistanceIteration / participant.CurrentSpeed)
                                              * Track.SurfaceCondition * Track.WeatherCondition;
                    participant.DistancePassed += RaceDistanceIteration;

                    distance -= RaceDistanceIteration;
                }

                if (distance <= 0)
                {
                    Console.WriteLine($"\n-------Participant {participant} finished the race!-------\n");
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

        /// <summary>
        /// Async method for starting the race. Delays task execution simulating real race.
        /// </summary>
        /// <param name="participant"></param>
        /// <returns>Task object.</returns>
        private async Task RunParticipantAsync(RacingCar participant)
        {
            participant.EngineHealthChanged += RacingCarEventListener.HealthChanged;
            participant.EngineIsAboutToBlow += RacingCarEventListener.AboutToBlow;
            participant.EngineHasDied += RacingCarEventListener.EngineHasBlown;
            participant.SpeedChanged += RacingCarEventListener.SpeedChanged;

            try
            {
                double distance = Track.LapDistance * Track.LapAmount;
                double time;

                Console.WriteLine(participant + " started the race!\n");
                while (distance >= 0 && participant.StillAlive())
                {
                    participant.Accelerate();

                    time = (RaceDistanceIteration / participant.CurrentSpeed)
                           * Track.SurfaceCondition * Track.WeatherCondition;

                    participant.TimePassed += time;

                    participant.DistancePassed += RaceDistanceIteration;

                    distance -= RaceDistanceIteration;

                    await Task.Delay((int)time * 1000);
                }

                if (distance <= 0)
                {
                    Console.WriteLine($"\n-------Participant {participant} finished the race!-------\n");
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
