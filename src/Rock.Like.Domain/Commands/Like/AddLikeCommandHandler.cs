using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Rock.Like.Core.Commands;
using Rock.Like.Core.Communication.Mediator;
using Rock.Like.Domain.Repository;
using Rock.Like.Domain.Entities;

namespace Rock.Like.Domain.Commands
{
    public class AddLikeCommandHandler : CommandHandler, IRequestHandler<AddLikeCommand, bool>
    {
        private readonly IArticleRepository _articleRepository;
        public AddLikeCommandHandler(IMediatorHandler mediatorHandler, IArticleRepository articleRepository) : base(mediatorHandler)
        {
            _articleRepository = articleRepository;
        }

        public async Task<bool> Handle(AddLikeCommand command, CancellationToken cancellationToken)
        {
            var article = await _articleRepository.GetArticleAsync(command.AggregateId);
            if(article is null)
            {
                await this.AddNotification(nameof(Article), "Article not found!");
                return false;
            }

            article.AddLike();

            return await _articleRepository.UnitOfWork.Commit();
        }
    }
}
