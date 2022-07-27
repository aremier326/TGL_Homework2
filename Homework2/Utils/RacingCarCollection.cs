using System.Collections;

namespace Homework2.Utils
{
    /// <summary>
    /// Represents collection of RacingCar obj.
    /// </summary>
    public class RacingCarCollection : IEnumerable<RacingCar>
    {
        public delegate void CarAdded(object sender, RacingCarEventArgs args);
        public delegate void CarRemoved(object sender, RacingCarEventArgs args);

        public event CarAdded OnCarAdded = delegate {};
        public event CarRemoved OnCarRemoved = delegate {};

        private readonly List<RacingCar> _cars = new();

        /// <summary>
        /// Simple iterator
        /// </summary>
        /// <param name="index">Index of desired element.</param>
        /// <returns>RacingCar obj by index.</returns>
        public RacingCar this[int index]
        {
            get => _cars[index];
            set => _cars[index] = value;
        }

        /// <summary>
        /// Creates instance of RacingCarCollection.
        /// </summary>
        public RacingCarCollection()
        {
            OnCarAdded += RacingCarEventListener.RacingCarAdded;
            OnCarRemoved += RacingCarEventListener.RacingCarRemoved;
        }

        /// <summary>
        /// Returns amount of cars.
        /// </summary>
        public int Count => _cars.Count;

        /// <summary>
        /// Adds car obj to the end of the collection. 
        /// </summary>
        /// <param name="car">RacingCar instance.</param>
        public void Add(RacingCar car)
        {
            _cars.Add(car);
            OnCarAdded.Invoke(car, new RacingCarEventArgs(car + " joined the race!"));
        }

        /// <summary>
        /// Removes first occurance of car obj from the collection. 
        /// </summary>
        /// <param name="car">RacingCar instance.</param>
        public void Remove(RacingCar car)
        {
            _cars.Remove(car);
            OnCarRemoved.Invoke(car, new RacingCarEventArgs(car + " was removed from race!"));
        }
        
        public IEnumerator<RacingCar> GetEnumerator()
        {
            return _cars.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

