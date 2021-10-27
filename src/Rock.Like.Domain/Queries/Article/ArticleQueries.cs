using Rock.Like.Domain.DTOs;
using Rock.Like.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rock.Like.Domain.Queries
{
    public class ArticleQueries : IArticleQueries
    {
        private readonly IArticleRepository _articleRepository;
        public ArticleQueries(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public async Task<IEnumerable<ArticleDTO>> GetArticlesAsync()
        {
            var articles = await _articleRepository.GetArticlesAsync();
            if (!articles.Any()) return new List<ArticleDTO>();

            return articles.Select(article => new ArticleDTO
            {
                Id = article.Id,
                TotalLikes = article.TotalLikes
            });
        }

        public async Task<ArticleDTO> GetArticleAsync(Guid id)
        {
            var article = await _articleRepository.GetArticleAsync(id);
            if (article is null) return null;

            return new ArticleDTO()
            {
                Id = article.Id,
                TotalLikes = article.TotalLikes
            };
        }
    }
}
