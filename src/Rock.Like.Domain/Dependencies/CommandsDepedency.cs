using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Rock.Like.Domain.Commands;
using Rock.Like.Domain.Queries;

namespace Rock.Like.Domain.Dependencies
{
    public static class CommandsDepedency
    {
        public static void AddDomainModule(this IServiceCollection services)
        {
            services.AddScoped<IArticleQueries, ArticleQueries>();

            services.AddScoped<IRequestHandler<AddLikeCommand, bool>, AddLikeCommandHandler>();
        }
    }
}
