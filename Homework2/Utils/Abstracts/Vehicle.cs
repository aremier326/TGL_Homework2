using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Homework2.Utils.Abstracts
{
    public abstract class Vehicle
    {
        public double MaxSpeed { get; init; }
        public double GasAmount { get; set; }
        public double CurrentSpeed { get; set; }
        public abstract int EngineHealth { get; set; }


    }
}