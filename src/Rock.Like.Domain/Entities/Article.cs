using Rock.Like.Core.DomainObjects;

namespace Rock.Like.Domain.Entities
{
    public class Article : Entity, IAggregateRoot
    {
        public Article()
        {
            TotalLikes = 0;
        }

        public int TotalLikes { get; private set; }

        public void AddLike() => TotalLikes += 1;
    }
}
