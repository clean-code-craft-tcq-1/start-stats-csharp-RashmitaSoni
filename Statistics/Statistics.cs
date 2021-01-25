using System;
using System.Linq;
using System.Collections.Generic;

namespace Statistics
{
    public class StatsComputer
    {
        public int CalculateStatistics(List<float> numbers) {
            //Implement statistics here
            float average, min, max;
            min = numbers.Min(); //calculating min
            max = numbers.Max(); //calculating max
            average = numbers.Average(); //calculating average
            return 1;
        }
    }
}
