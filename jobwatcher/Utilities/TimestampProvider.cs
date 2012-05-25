using System;

namespace jobwatcher.Utilities
{
    public interface ITimestampProvider
    {
        string GetTimestamp();
    }

    public class TimestampProvider : ITimestampProvider
    {
        public string GetTimestamp()
        {
            var now = DateTime.Now;
            return now.ToShortDateString() + " " + now.ToShortTimeString();
        }
    }
}