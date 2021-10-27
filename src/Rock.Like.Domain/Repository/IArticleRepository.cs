using Rock.Like.Domain.Entities;
using System.Threading.Tasks;
using Rock.Like.Core.Data;
using System;
using System.Collections.Generic;

namespace Rock.Like.Domain.Repository
{
    public interface IArticleRepository : IRepository<Article>
    {
        Task<IEnumerable<Article>> GetArticlesAsync();
        Task<Article> GetArticleAsync(Guid id);
    }
}
