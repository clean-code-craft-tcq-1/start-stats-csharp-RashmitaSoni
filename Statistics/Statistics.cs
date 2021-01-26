using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statistics
{
    class StatsComputer
    {
        public float average { get; set; }
        public float min { get; set; }
        public float max { get; set; }
        public double CalculateStatistics(List<float> numbers)
        {
            if (numbers.Any(i => i != 0.0f))
            {
                this.min = numbers.Min();
                this.max = numbers.Max();
                this.average = numbers.Average();

                return 1;
            }
            else
            {
                return Double.NaN;
            }

        }
            
            
        }
    public interface IAlerter
    {
          

    }
    class EmailAlert : IAlerter
    {
            public bool emailSent { get; set; }
            public EmailAlert() { this.emailSent = true; }
    }
    class LEDAlert : EmailAlert,IAlerter
    {
           public bool ledGlows { get; set; }
           public LEDAlert() { this.ledGlows = true; }

    }

    class StatsAlerter: LEDAlert
    {
        public float threshold { get; set; }
        public StatsAlerter(float maxThreshold, IAlerter[] alerters)
        {
            
            this.threshold = maxThreshold;
          
        }
        public void checkAndAlert(List<float> numbers)
        {
            if (numbers.Max() > this.threshold)
            {
                this.emailSent = true;
                this.ledGlows = true;
            }

        }

    }
   

}


