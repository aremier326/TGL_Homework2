using Homework2.Utils.Abstracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2.Utils
{
    public class RacingCar : Vehicle, IEnumerable<RacingCar>
    {
        public override int EngineHealth
        {
            get => default;
            set
            {
                
            }
        }

        public Racer? Racer { get; init; }


        public IEnumerator<RacingCar> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
