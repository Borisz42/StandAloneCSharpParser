using System;
using static System.Console;

namespace StandAloneCSharpParser
{
    public class Test
    {
        public bool IsPositive(int input)
        {
            return input > 0;
        }

        public delegate bool isPos(int input);

        public Test()
        {
            isPos del = IsPositive;
            int two = 2;
            WriteLine($"\n 2 is positive = {del(two)}");
        }
    }
    public class SampleEventArgs
    {
        public SampleEventArgs(string text) { Text = text; }
        public string Text { get; } // readonly
    }
    public class Publisher
    {
        public delegate void SampleEventHandler(object sender, SampleEventArgs e);

        public event SampleEventHandler SampleEvent;

        protected virtual void RaiseSampleEvent()
        {
            // Raise the event in a thread-safe manner using the ?. operator.
            SampleEvent?.Invoke(this, new SampleEventArgs("Hello"));
        }
    }
    class TimePeriod
    {
        private double _seconds;

        public int minutes { get; set; }

        public double Hours
        {
            get { return _seconds / 3600; }
            set
            {
                if (value < 0 || value > 24)
                    throw new ArgumentOutOfRangeException($"{nameof(value)} must be between 0 and 24.");

                _seconds = value * 3600;
            }
        }
    }

}
