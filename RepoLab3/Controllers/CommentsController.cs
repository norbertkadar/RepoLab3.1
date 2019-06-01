
using System.Collections.Generic;
using curs_2_webapi.Services;
using curs_2_webapi.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace RepoLab3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private ICommentService commentService;

        /// <summary>
        /// Note: might work without constructor as well.
        /// </summary>
        /// <param name="commentService"></param>
        public CommentsController(ICommentService commentService)
        {
            this.commentService = commentService;
        }

        [HttpGet]
        public IEnumerable<CommentGetModel> Get([FromQuery]string filterString)
        {
            return commentService.GetAll(filterString);
        }
    }
}