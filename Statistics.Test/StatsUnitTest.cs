using System;
using System.Linq;
using System.Collections.Generic;
using Xunit;
using Statistics;

namespace Statistics.Test
{
    public class StatsUnitTest
    {
        [Fact]
        public void ReportsAverageMinMax()
        {
            var statsComputer = new StatsComputer();
            List<float> numbers = new List<float>();
            numbers.Add((float)1.5);
            numbers.Add((float)8.9);
            numbers.Add((float)3.2);
            numbers.Add((float)4.5);
            var computedStats = statsComputer.CalculateStatistics(numbers);
            float epsilon = 0.001F;
            Assert.True(Math.Abs(statsComputer.average - 4.525) <= epsilon);
            Assert.True(Math.Abs(statsComputer.max - 8.9) <= epsilon);
            Assert.True(Math.Abs(statsComputer.min - 1.5) <= epsilon);
        }
        [Fact]
        public void ReportsNaNForEmptyInput()
        {
            var statsComputer = new StatsComputer();
            List<float> numbers = new List<float>();
            var computedStats = statsComputer.CalculateStatistics(numbers);
            //All fields of computedStats (average, max, min) must be
            //Double.NaN (not-a-number), as described in
            //https://docs.microsoft.com/en-us/dotnet/api/system.double.nan?view=netcore-3.1
        }
        [Fact]
        public void RaisesAlertsIfMaxIsMoreThanThreshold()
        {
            var emailAlert = new EmailAlert();
            var ledAlert = new LEDAlert();
            IAlerter[] alerters = {emailAlert, ledAlert};

            const float maxThreshold = 10.2f;
            List<float> numbers = new List<float>();
            numbers.Add((float)0.2);
            numbers.Add((float)11.9);
            numbers.Add((float)4.3);
            numbers.Add((float)8.5);
            var statsAlerter = new StatsAlerter(maxThreshold, alerters);
            statsAlerter.checkAndAlert(numbers);

            Assert.True(emailAlert.emailSent);
            Assert.True(ledAlert.ledGlows);
        }
    }
}
