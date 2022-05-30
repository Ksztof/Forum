using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommentToAnswerC = Forum.Domain.Models.CommentToAnswer;
namespace Forum.Core.Models.CommentToAnswer
{
    public class UpdateCommentToAnswerFM
    {
        [Required]
        public string CommentToAnswerContent { get; set; }

        public CommentToAnswerC changeCommentToAnswerData(CommentToAnswerC commentToAnswer)
        {
            commentToAnswer.CommentToAnswerContent = CommentToAnswerContent;
            return commentToAnswer;
        }

    }
}
