using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomNumberGenerators
{
    public class RandomInRange
    {

        int _min;
        int _max;

        public Random random { get; set; }

        public RandomInRange() : this(0, 0) { }

        public RandomInRange(int min, int max)
        {
            _min = min;
            _max = max;
            random = new Random();
        }

        public virtual int GetRandomNumber()
        {
            return (int)(random.NextDouble() * (_max - _min) + _min);
        }

    }
}
