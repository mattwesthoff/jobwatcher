using PusherRESTDotNet;
using jobwatcher.Models;

namespace jobwatcher.Utilities
{
    public interface IMessagePusher
    {
        Job JobCreated(string text, int id);
        void JobFinished(int id);
    }

    public class MessagePusher : IMessagePusher
    {
        private readonly ITimestampProvider _timestamps;
        private readonly IPusherProvider _pusher;

        public MessagePusher(ITimestampProvider timestamps, IPusherProvider pusher)
        {
            _timestamps = timestamps;
            _pusher = pusher;
        }

        public Job JobCreated(string text, int id)
        {
            var job = new Job {Id = id, Text = text, Status = "Started", Timestamp = _timestamps.GetTimestamp()};
            _pusher.Trigger(new ObjectPusherRequest("job_channel", "job_created", job));

            return job;
        }

        public void JobFinished(int id)
        {
            _pusher.Trigger(
                new ObjectPusherRequest(
                    "job_channel",
                    "job_finished",
                    new
                        {
                            id,
                            timestamp = _timestamps.GetTimestamp()
                        })
                );
        }
    }
}