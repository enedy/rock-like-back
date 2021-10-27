using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Rock.Like.Core.Communication.Mediator;
using Rock.Like.Core.Data;
using Rock.Like.Core.DomainObjects;
using Rock.Like.Domain.Entities;

namespace Rock.Like.Data.Contexts
{
    public class DBContext : DbContext, IUnitOfWork
    {
        private readonly IMediatorHandler _mediatorHandler;

        public DBContext(DbContextOptions<DBContext> options, IMediatorHandler mediatorHandler)
            : base(options)
        {
            _mediatorHandler = mediatorHandler;
        }

        public DbSet<Article> Article { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Entity>();
            modelBuilder.Entity<Article>().HasData(
               new Article(),
               new Article(),
               new Article(),
               new Article(),
               new Article(),
               new Article(),
               new Article()
           );
        }

        public async Task<bool> Commit() => await base.SaveChangesAsync() > 0;
    }
}
