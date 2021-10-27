using Microsoft.Extensions.DependencyInjection;
using Rock.Like.Data.Contexts;
using Rock.Like.Domain.Entities;
using System.Linq;

namespace Rock.Like.Data.Initialize
{
    public class DbInitializer : IDbInitializer
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public DbInitializer(IServiceScopeFactory scopeFactory)
        {
            this._scopeFactory = scopeFactory;
        }

        public void Initialize()
        {
            using (var serviceScope = _scopeFactory.CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<DBContext>())
                {
                    context.Database.EnsureCreated();
                }
            }
        }

        public void SeedData()
        {
            using (var serviceScope = _scopeFactory.CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<DBContext>())
                {

                    if (!context.Article.Any())
                    {
                        var article = new Article();
                        context.Article.Add(article);
                    }

                    context.SaveChanges();
                }
            }
        }
    }
}
