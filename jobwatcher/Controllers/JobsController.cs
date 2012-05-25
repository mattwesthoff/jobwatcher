using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using AttributeRouting;
using AttributeRouting.Web.Http;
using jobwatcher.Models;
using jobwatcher.Utilities;

namespace jobwatcher.Controllers
{
    [RoutePrefix("jobs")]
    public class JobsController : ApiController
    {
        private readonly IMessagePusher _messagePusher;

        public JobsController(IMessagePusher messagePusher)
        {
            _messagePusher = messagePusher;
        }

        private static int _jobCount = 0;
        
        [GET("create")]
        [POST("create")]
        public Job CreateJob(string text = "hi")
        {
            var id = _jobCount;

            var job = _messagePusher.JobCreated(text, id);

            var runJobTask = new Task(() =>
            {
                var onebyte = new byte[] { 0x0 };
                new RNGCryptoServiceProvider("someseed").GetBytes(onebyte);
                Thread.Sleep(onebyte[0] * 25);
                _messagePusher.JobFinished(id);
            });

            _jobCount++;

            runJobTask.Start();

            return job;
        }
    }
}