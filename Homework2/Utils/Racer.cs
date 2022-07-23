using Homework2.Utils.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Homework2.Utils
{
    /// <summary>
    /// Class represents racing car driver.
    /// </summary>
    public class Racer : Person
    {
        public Racer(){}

        public Racer(string? name)
            : base(name) {}
    }
}