using Homework2.Utils.Abstracts;

namespace Homework2.Utils
{
    /// <summary>
    /// Represents racing car.
    /// </summary>
    public class RacingCar : Vehicle
    {
        //Events
        public event EventHandler<RacingCarEventArgs> EngineHealthChanged;
        public event EventHandler<RacingCarEventArgs> EngineIsAboutToBlow;
        public event EventHandler<RacingCarEventArgs> EngineHasDied;

        private double _timePassed;
        private double _currentSpeed;
        private double _engineHealth;

        public override double CurrentSpeed
        {
            get => _currentSpeed;
            set
            {
                if (value >= MaxSpeed - 10)
                {
                    EngineHealth -= 10;
                    EngineHealthChanged?.Invoke(this, new RacingCarEventArgs("Health decreased by 10 points"));
                }
                _currentSpeed = value;
            }
        }

        public override double EngineHealth
        {
            get => _engineHealth;
            set
            {
                if (value is > 0 and <= 10)
                {
                    EngineIsAboutToBlow?.Invoke(this, new RacingCarEventArgs("Engine health is critical!!!"));
                    _engineHealth = value;
                }
                else if (value <= 0)
                {
                    EngineHasDied?.Invoke(this, new RacingCarEventArgs("Engine has blown!"));
                    _engineHealth = 0;
                }
                else
                {
                    _engineHealth = value;
                }
            }
        }

        public double TimePassed
        {
            get => _timePassed;
            set
            {
                _timePassed = value;
            }
        }

        public Racer? Racer { get; init; }

        public RacingCar(){}
        public RacingCar(double maxSpeed, double gasAmount, Racer racer) : base(maxSpeed, gasAmount)
        {
            Racer = racer;
        }

        /// <summary>
        /// Check if car is still alive.
        /// </summary>
        public bool StillAlive()
        {
            return !(EngineHealth <= 0);
        }

        /// <summary>
        /// Updating current speed. (Can be improved surely)
        /// </summary>
        public void Accelerate()
        {
            Random r = new Random();
            CurrentSpeed = r.NextDouble() * 200 + 1;
        }

    }
}
