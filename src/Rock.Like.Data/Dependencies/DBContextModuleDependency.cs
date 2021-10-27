using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Rock.Like.Data.Contexts;
using Rock.Like.Data.Initialize;
using Rock.Like.Data.Repository;
using Rock.Like.Domain.Repository;

namespace Rock.Like.Data.Dependencies
{
    public static class DBContextModuleDependency
    {
        public static void AddDataBaseInMemoryModule(this IServiceCollection services)
        {
            services.AddDbContext<DBContext>(opt => opt.UseInMemoryDatabase(databaseName: "RockLike"));

            services.AddScoped<IArticleRepository, ArticleRepository>();
            services.AddScoped<IDbInitializer, DbInitializer>();
        }
    }
}
