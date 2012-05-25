using Autofac;
using PusherRESTDotNet;
using jobwatcher.Utilities;

namespace jobwatcher
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //could be in the web.config
            const string appId = "21150";
            const string key = "9ce2c2e966baaaa28ce6";
            const string secret = "2461cc3fb6d02f49a4e6";

            builder.RegisterType<MessagePusher>().As<IMessagePusher>();
            builder.RegisterType<TimestampProvider>().As<ITimestampProvider>();
            builder.Register<IPusherProvider>(c => new PusherProvider(appId, key, secret)).SingleInstance();
            base.Load(builder);
        }
    }
}