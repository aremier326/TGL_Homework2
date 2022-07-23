using System.Threading;
using System.Threading.Tasks;
using Homework2.Utils.Abstracts;

namespace Homework2.Utils
{
    public class RacingSimulator
    {
        public Track? Track { get; init; }

        private IEnumerable<RacingCar>? participants;

        public Racer? Winner;

        
        private void RunParticipant(RacingCar participant)
        {
            try
            {
                double distance = Track.LapDistance * Track.LapAmount;

                var time = 0.0;
                while (distance >= 0 && participant.StillAlive())
                {
                    participant.Accelerate();

                    participant.TimePassed += (50 / participant.CurrentSpeed)
                                              * Track.SurfaceCondition * Track.WeatherCondition;

                    distance -= 50;
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
