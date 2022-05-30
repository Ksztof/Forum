using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommentToCommentC = Forum.Domain.Models.CommentToComment;
namespace Forum.Core.Models.CommentToComment
{
    public class AddCommentToCommentFM
    {
        [Required]
        public string CommentToCommentContent { get; set; }
        public int AppUserId { get; set; }  
        public CommentToCommentC Construct(int commentToCommentId, int appUserId)
        {
            return new CommentToCommentC()
            {
                CommentToCommentContent = CommentToCommentContent,
                CommentToAnswerId = commentToCommentId,
                AppUserId = appUserId,
            };
        }

        public CommentToCommentC UpdateCommentToCommentContent(CommentToCommentC commentToComment)
        {
            commentToComment.CommentToCommentContent = CommentToCommentContent;
            return commentToComment;
        }
    }
}
