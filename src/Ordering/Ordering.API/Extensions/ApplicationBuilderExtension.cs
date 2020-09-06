using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Ordering.API.RabbitMq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ordering.API.Extensions
{
    public static class ApplicationBuilderExtension
    {
        public static EventBusRabbitMqConsumer Listener { get; set; }
        public static IApplicationBuilder UseRabbitListener(this IApplicationBuilder app)
        {
            Listener = app.ApplicationServices.GetService<EventBusRabbitMqConsumer>();
            var lifetime = app.ApplicationServices.GetService<IHostApplicationLifetime>();

            lifetime.ApplicationStarted.Register(OnStarted);
            lifetime.ApplicationStopped.Register(OnStopping);

            return app;
        }

        private static void OnStopping()
        {
            Listener.Disconnect();
        }

        private static void OnStarted()
        {
            Listener.Consume();
        }
    }
}
