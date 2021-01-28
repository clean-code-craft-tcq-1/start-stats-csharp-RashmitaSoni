using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statistics
{
    public struct State
    {
        public float average { get; set; }
        public float min { get; set; }
        public float max { get; set; }


    }


    public class StatsComputer
    {
        public float average;
        public float max;
        public float min;
        State state = new State();
        public State CalculateStatistics(List<float> numbers)
        {
          
            if (numbers.Any(i => i != 0.0f))
            {
                state.min = numbers.Min();
                state.max = numbers.Max();
                state.average = numbers.Average();

                this.average = state.average;
                this.max = state.max;
                this.min = state.min;

                return state;
            }
            else
            {
                state.min = (float)Double.NaN;
                state.max = (float)Double.NaN;
                state.average = (float)Double.NaN;
                return state;
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


