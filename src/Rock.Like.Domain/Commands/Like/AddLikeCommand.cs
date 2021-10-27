using System;
using Rock.Like.Core.Messages;

namespace Rock.Like.Domain.Commands
{
    public class AddLikeCommand : Command
    {
        public Guid Id { get; private set; }

        public AddLikeCommand(Guid id)
        {
            this.AggregateId = id;
        }
    }
}
