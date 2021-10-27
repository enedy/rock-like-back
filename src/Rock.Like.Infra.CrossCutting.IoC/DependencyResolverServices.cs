using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Rock.Like.Core.Communication.Mediator;
using Rock.Like.Core.Messages.Notifications;
using Rock.Like.Core.Messages.Notifications.Mediator;
using Rock.Like.Data.Dependencies;
using Rock.Like.Domain.Dependencies;

namespace Rock.Like.Infra.CrossCutting.IoC
{
    public static class DependencyResolverServices
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddMediatR(typeof(DependencyResolverServices));
            services.AddScoped<IMediatorHandler, MediatorHandler>();
            // Notifications
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            services.AddDataBaseInMemoryModule();
            services.AddDomainModule();
        }
    }
}
