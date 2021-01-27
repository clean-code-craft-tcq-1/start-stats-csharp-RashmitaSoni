using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statistics
{
    public class StatsComputer
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
                this.min = (float)Double.NaN;
                this.max = (float)Double.NaN;
                this.average = (float)Double.NaN;
                return Double.NaN;
            }

        }


    }
    public interface IAlerter
    {
        bool emailSent { get; set; }
        bool ledGlows { get; set; }
  
    }
    public class EmailAlert : IAlerter
    {
        public bool emailSent { get; set; }
        public bool ledGlows { get; set; }
      
    }
    public class LEDAlert : IAlerter
    {
        public bool emailSent { get; set; }
        public bool ledGlows { get; set; }
        

    }

    public class StatsAlerter
    {
        public float threshold { get; set; }
        IAlerter[] alerter;
        public StatsAlerter(float maxThreshold, IAlerter[] alerter)
        {
            this.threshold = maxThreshold;
            this.alerter = alerter;
            
        }
        public void checkAndAlert(List<float> numbers)
        {
            if (numbers.Max() > this.threshold)
            {
                this.alerter[0].emailSent = true;
                this.alerter[1].ledGlows = true;
            }

        }

    }
   

}


