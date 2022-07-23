using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Homework2.Utils.Abstracts
{
    /// <summary>
    /// Class represent abstract Vehicle object.
    /// </summary>
    public abstract class Vehicle
    {
        
        public double MaxSpeed { get; init; }
        public double GasAmount { get; set; }
        public virtual double DistancePassed { get; set; }
        public virtual double CurrentSpeed { get; set; }
        public virtual double EngineHealth { get; set; }

        protected Vehicle() {}
        
        protected Vehicle(double maxSpeed, double gasAmount)
        {
            MaxSpeed = maxSpeed;
            GasAmount = gasAmount;
        }
    }
}