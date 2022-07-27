using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2.Utils
{
    /// <summary>
    /// Contains RacingCar event listeners.
    /// </summary>
    public static class RacingCarEventListener
    {
        public static void HealthChanged(object? sender, RacingCarEventArgs e)
        {
            if (sender is RacingCar car)
            {
                Console.WriteLine($"Racer {car} be more careful! {e.msg}. Current health is {car.EngineHealth}");
            }
        }

        public static void AboutToBlow(object? sender, RacingCarEventArgs e)
        {
            if (sender is RacingCar car)
            {
                Console.WriteLine($"Racer {car} SLOW DOWN! {e.msg}");
            }
        }

        public static void EngineHasBlown(object? sender, RacingCarEventArgs e)
        {
            if (sender is RacingCar car)
            {
                Console.WriteLine($"\n-------Racer {car} has been disqualified! {e.msg}-------\n");
            }
        }
    }
}
