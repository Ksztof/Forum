using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommentToCommentC = Forum.Domain.CommentToComment;
namespace Forum.Core.Models.CommentToComment
{
    public class AddCommentToCommentFM
    {
        [Required]
        public string CommentToCommentContent { get; set; }

        public CommentToCommentC Construct(int commentToCommentId)
        {
            return new CommentToCommentC()
            {
                CommentToCommentContent = CommentToCommentContent,
                CommentToAnswerId = commentToCommentId,
            };
        }

        public CommentToCommentC UpdateCommentToCommentContent(CommentToCommentC commentToComment)
        {
            commentToComment.CommentToCommentContent = CommentToCommentContent;
            return commentToComment;
        }
    }
}
