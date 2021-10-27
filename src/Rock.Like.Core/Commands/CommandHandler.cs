using FluentValidation.Results;
using Rock.Like.Core.Communication.Mediator;
using Rock.Like.Core.Messages;
using Rock.Like.Core.Messages.Notifications;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rock.Like.Core.Commands
{
    public abstract class CommandHandler
    {
        public readonly IMediatorHandler _mediatorHandler;
        public CommandHandler(IMediatorHandler mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
        }

        public async Task<bool> ValidateCommand(Command command)
        {
            if (command.IsValid()) return true;

            await this.AddNotifications(command.ValidationResult.Errors);

            return false;
        }

        private async Task AddNotifications(IList<ValidationFailure> errors)
        {
            foreach (var error in errors)
                await AddNotification(error.ErrorCode, error.ErrorMessage);
        }

        public async Task AddNotification(string key, string message)
        {
            await _mediatorHandler.PublishNotification(new DomainNotification(key, message));
        }
    }
}
