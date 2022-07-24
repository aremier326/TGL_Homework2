namespace Homework2.Utils.Abstracts
{
    /// <summary>
    /// Class represent abstract Vehicle object.
    /// </summary>
    public abstract class Vehicle
    {
        #region Props
        public string ModelName { get; init; }
        public double MaxSpeed { get; init; }
        public double GasAmount { get; set; }
        public virtual double DistancePassed { get; set; }
        public virtual double CurrentSpeed { get; set; }
        public virtual double EngineHealth { get; set; }

        #endregion

        /// <summary>
        /// Default constructor.
        /// </summary>
        protected Vehicle() {}
        
        /// <summary>
        /// Creates instance of abstract Vehicle object.
        /// </summary>
        /// <param name="modelName">Car name.</param>
        /// <param name="maxSpeed">Maximal speed.</param>
        /// <param name="gasAmount">Amount of gas.</param>
        protected Vehicle(string? modelName, double maxSpeed, double gasAmount)
        {
            ModelName = modelName;
            MaxSpeed = maxSpeed;
            GasAmount = gasAmount;
        }
    }
}