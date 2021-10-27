using Rock.Like.Core.Messages;
using Rock.Like.Core.Messages.Notifications;
using System.Threading.Tasks;

namespace Rock.Like.Core.Communication.Mediator
{
    public interface IMediatorHandler
    {
        Task<bool> SendCommand<T>(T command) where T : Command;
        Task PublishNotification<T>(T notification) where T : DomainNotification;
    }
}
