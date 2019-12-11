using System;

namespace NumberGenerator.Logic
{
    /// <summary>
    /// Beobachter, welcher einfache Statistiken bereit stellt (Min, Max, Sum, Avg).
    /// </summary>
    public class StatisticsObserver : BaseObserver
    {
        #region Fields

        int _min = -1;
        int _max = -1;
        int _sum = 0;
        int _avg = 0;
        int _counter = 0;

        #endregion

        #region Properties

        /// <summary>
        /// Enthält das Minimum der generierten Zahlen.
        /// </summary>
        public int Min { get; private set; }

        /// <summary>
        /// Enthält das Maximum der generierten Zahlen.
        /// </summary>
        public int Max { get; private set; }

        /// <summary>
        /// Enthält die Summe der generierten Zahlen.
        /// </summary>
        public int Sum { get; private set; }

        /// <summary>
        /// Enthält den Durchschnitt der generierten Zahlen.
        /// </summary>
        public int Avg { get; private set; }

        #endregion

        #region Constructors

        public StatisticsObserver(IObservable numberGenerator, int countOfNumbersToWaitFor) : base(numberGenerator, countOfNumbersToWaitFor)
        {
        }

        #endregion

        #region Methods

        public override string ToString()
        {
            return $"{base.ToString()} => StatisticsObserver [Min='{Min}', Max='{Max}', Sum='{Sum}', Avg='{Avg}']";
        }

        public override void OnNextNumber(int number)
        {
            _counter++;
            if (_min == -1)
            {
                _min = number;
            }
            else if (number < _min)
            {
                _min = number;
            }
            if (_max == -1)
            {
                _max = number;
            }
            else if (number > _max)
            {
                _max = number;
            }
            _sum = _sum + number;

            _avg = _sum / _counter;
            Avg = _avg;
            Min = _min;
            Max = _max;
            Sum = _sum;


            base.OnNextNumber(number);
        }
        #endregion
    }
}