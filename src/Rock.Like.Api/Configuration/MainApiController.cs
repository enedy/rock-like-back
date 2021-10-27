using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Rock.Like.Core.Communication.Mediator;
using Rock.Like.Core.Messages.Notifications;
using Rock.Like.Core.Messages.Notifications.Mediator;

namespace Rock.Like.Api.Configuration
{
    [ApiController]
    public abstract class MainApiController : ControllerBase
    {
        private readonly DomainNotificationHandler _notifications;
        protected readonly IMediatorHandler _mediatorHandler;
        protected MainApiController(INotificationHandler<DomainNotification> notifications, IMediatorHandler mediatorHandler)
        {
            _notifications = (DomainNotificationHandler)notifications;
            _mediatorHandler = mediatorHandler;
        }

        /// <summary>
        /// Check Operation
        /// </summary>
        /// <returns></returns>
        protected bool CheckOperation()
        {
            return !_notifications.ExistsNotification();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="result"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        protected ActionResult<T> CustomOk<T>(T result, string message = null)
        {
            if (_notifications.ExistsNotification())
            {
                return BadRequest(
                    new
                    {
                        Success = false,
                        Data = result,
                        Message = _notifications.GetNotificationsByValue()
                    });
            }

            return Ok(new
            {
                Success = true,
                Data = result,
                Message = message
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        protected ActionResult CustomOk(string message = null)
        {
            if (_notifications.ExistsNotification())
            {
                return BadRequest(
                    new
                    {
                        Success = false,
                        Message = _notifications.GetNotificationsByValue()
                    });
            }

            return Ok(new
            {
                Success = true,
                Message = message
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected ActionResult CustomNoContent()
        {
            if (_notifications.ExistsNotification())
            {
                return BadRequest(
                    new
                    {
                        Success = false,
                        Message = _notifications.GetNotificationsByValue()
                    });
            }

            return NoContent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="action"></param>
        /// <param name="result"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        protected ActionResult<T> Created<T>(T result, string action, string message = null)
        {
            if (_notifications.ExistsNotification())
            {
                return BadRequest(
                    new
                    {
                        Success = false,
                        Data = result,
                        Message = _notifications.GetNotificationsByValue()
                    });
            }

            return CreatedAtAction(action, new
            {
                Success = true,
                Data = result,
                Message = message
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        protected ActionResult CustomNotFound(string message)
        {
            return NotFound(new
            {
                Success = false,
                Message = message
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        protected ActionResult CustomUnauthorized(string message)
        {
            return Unauthorized(new
            {
                Success = false,
                Message = message
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        protected ActionResult CustomResponseError(string message)
        {
            return BadRequest(new
            {
                Success = false,
                Message = message
            });
        }
    }
}
