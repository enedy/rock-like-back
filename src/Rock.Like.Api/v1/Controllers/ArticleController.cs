using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Rock.Like.Api.Configuration;
using Rock.Like.Core.Communication.Mediator;
using Rock.Like.Core.Messages.Notifications;
using Rock.Like.Domain.Commands;
using Rock.Like.Domain.DTOs;
using Rock.Like.Domain.Queries;
using Swashbuckle.AspNetCore.Annotations;

namespace Rock.Like.Api.v1.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/articles")]
    public class ArticleController : MainApiController
    {
        private readonly IArticleQueries _articleQueries;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="notifications"></param>
        /// <param name="mediatorHandler"></param>
        /// <param name="articleQueries"></param>
        public ArticleController(INotificationHandler<DomainNotification> notifications,
        IMediatorHandler mediatorHandler, IArticleQueries articleQueries) : base(notifications, mediatorHandler)
        {
            _articleQueries = articleQueries;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = null, Type = typeof(ArticleDTO))]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Description = null, Type = typeof(string))]
        public async Task<ActionResult<IEnumerable<ArticleDTO>>> Get()
        {
            return CustomOk(await _articleQueries.GetArticlesAsync());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("{id}"), HttpGet]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = null, Type = typeof(ArticleDTO))]
        [SwaggerResponse((int)HttpStatusCode.NotFound, Description = null, Type = typeof(string))]
        public async Task<ActionResult<ArticleDTO>> Get(Guid id)
        {
            var articleDTO = await _articleQueries.GetArticleAsync(id);

            if (articleDTO is not null)
                return CustomOk(articleDTO);
            else
                return CustomNotFound("Article not found!");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("{id}"), HttpPut]
        [SwaggerResponse((int)HttpStatusCode.OK, Description = null)]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Description = null)]
        public async Task<ActionResult> Put(Guid id)
        {
            await _mediatorHandler.SendCommand(new AddLikeCommand(id));
            return CustomNoContent();
        }
    }
}
