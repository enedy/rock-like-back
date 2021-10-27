using Microsoft.EntityFrameworkCore;
using Rock.Like.Core.Data;
using Rock.Like.Data.Contexts;
using Rock.Like.Domain.Entities;
using Rock.Like.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rock.Like.Data.Repository
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly DBContext _context;
        public ArticleRepository(DBContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public void Dispose() => _context?.Dispose();

        public async Task<IEnumerable<Article>> GetArticlesAsync()
        {
            return await _context.Article.ToListAsync();
        }

        public async Task<Article> GetArticleAsync(Guid id)
        {
            return await _context.Article.FirstOrDefaultAsync(article => article.Id == id);
        }
    }
}
