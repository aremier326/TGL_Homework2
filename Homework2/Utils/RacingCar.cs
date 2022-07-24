using Homework2.Utils.Abstracts;

namespace Homework2.Utils
{
    /// <summary>
    /// Represents racing car.
    /// </summary>
    public class RacingCar : Vehicle
    {
        #region Events

        public event EventHandler<RacingCarEventArgs> EngineHealthChanged;
        public event EventHandler<RacingCarEventArgs> EngineIsAboutToBlow;
        public event EventHandler<RacingCarEventArgs> EngineHasDied;

        #endregion


        #region PrivateValues

        private double _timePassed;
        private double _currentSpeed;
        private double _engineHealth = 100;

        #endregion

        /// <summary>
        /// Contains current speed value, can change engine health status.
        /// </summary>
        public override double CurrentSpeed
        {
            get => _currentSpeed;
            set
            {
                if (value >= MaxSpeed - 10)
                {
                    EngineHealth -= 10;
                    if(StillAlive())
                        EngineHealthChanged?.Invoke(this, new RacingCarEventArgs("Health decreased by 10 points"));
                }
                _currentSpeed = value;
            }
        }

        /// <summary>
        /// Changes engine health status, invokes events.
        /// </summary>
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
        
        /// <summary>
        /// Contains participant race time.
        /// </summary>
        public double TimePassed
        {
            get => _timePassed;
            set => _timePassed = value;
        }

        /// <summary>
        /// Racer object.
        /// </summary>
        public Racer? Racer { get; init; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public RacingCar(){}

        /// <summary>
        /// Creates instance of RacingCar object.
        /// </summary>
        /// <param name="modelName">Name of the car.</param>
        /// <param name="maxSpeed">Maximal speed of car.</param>
        /// <param name="gasAmount">Amount of gas (can be useful in future).</param>
        /// <param name="racer">Racer obj.</param>
        public RacingCar(string? modelName, double maxSpeed, double gasAmount, Racer racer)
            : base(modelName, maxSpeed, gasAmount)
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
            //if (!StillAlive())
            //{
            //    EngineHasDied?.Invoke(this, new RacingCarEventArgs("Engine has died!"));
            //}
            CurrentSpeed = new Random().NextDouble() * 200 + 1;
        }

        /// <summary>
        /// Compares racing car objects by TimePassed param.
        /// </summary>
        /// <param name="other"></param>
        /// <returns> Result of comparing TimePassed param in 2 RacingCar obj. </returns>
        public int CompareTo(RacingCar? other)
        {
            return this.TimePassed.CompareTo(other?.TimePassed);
        }

        /// <summary>
        /// ToString override for displaying general info about race participant.
        /// </summary>
        /// <returns>String value of participant info.</returns>
        public override string ToString()
        {
            return $"{Racer?.Name} driving {ModelName}";
        }
    }
}
