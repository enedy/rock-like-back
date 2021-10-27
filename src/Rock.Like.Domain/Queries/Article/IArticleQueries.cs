using Rock.Like.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rock.Like.Domain.Queries
{
    public interface IArticleQueries
    {
        Task<IEnumerable<ArticleDTO>> GetArticlesAsync();
        Task<ArticleDTO> GetArticleAsync(Guid id);
    }
}
