using System.Threading;
using System.Threading.Tasks;
using Homework2.Utils.Abstracts;

namespace Homework2.Utils
{
    public class RacingSimulator
    {
        private Track? Track { get; }
        
        private List<RacingCar>? participants;


        public RacingSimulator(){}

        public RacingSimulator(Track track, List<RacingCar> participants)
        {
            Track = track;
            this.participants = participants;
        }

        public static void HealthChanged(object sender, RacingCarEventArgs e)
        {
            if (sender is RacingCar car)
            {
                Console.WriteLine($"Racer {car} be more careful! {e.msg}");
            }
        }       

        public static void AboutToBlow(object sender, RacingCarEventArgs e)
        {
            if (sender is RacingCar car)
            {
                Console.WriteLine($"Racer {car} SLOW DOWN! {e.msg}");
            }
        }

        public static void EngineHasBlown(object sender, RacingCarEventArgs e)
        {
            if (sender is RacingCar car)
            {
                Console.WriteLine($"Racer {car} has been disqualified! {e.msg}");
            }
        }

        public void RunRace()
        {
            foreach (var participant in participants)
            {
                Console.WriteLine("running in foreach");
                RunParticipant(participant);
            }
            GetWinner();
        }


        private void GetWinner()
        {
            var winner = participants.Where(x => x.StillAlive()).Min();
            Console.WriteLine(winner != null
                ? $"Here is the winner! {winner}"
                : "Sorry, there is no winner!");
        }

        private void RunParticipant(RacingCar participant)
        {
            participant.EngineHealthChanged += HealthChanged;
            participant.EngineIsAboutToBlow += AboutToBlow;
            participant.EngineHasDied += EngineHasBlown;
            

            try
            {
                double distance = Track.LapDistance * Track.LapAmount;

                while (distance >= 0 && participant.StillAlive())
                {
                    participant.Accelerate();

                    participant.TimePassed += (50 / participant.CurrentSpeed)
                                              * Track.SurfaceCondition * Track.WeatherCondition;

                    distance -= 50;
                    //Console.WriteLine($"dist: {distance}, time: {participant.TimePassed}, " +
                    //                  $"curSpeed: {participant.CurrentSpeed}, engine: {participant.EngineHealth}");
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
