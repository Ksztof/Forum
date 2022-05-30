using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommentToAnswerC = Forum.Domain.Models.CommentToAnswer;
namespace Forum.Core.Models.CommentToAnswer
{
    public class CommentToAnswerAddFM
    {
        [Required]
        public int AnswerId { get; set; }
        [Required]
        public string CommentToAnswerContent { get; set; }
        public int AppUserId { get; set; }

        public CommentToAnswerC Construct(int answerId, int questionId, int appUserId)
        {
            return new CommentToAnswerC()
            {
                AnswerId = answerId,
                CommentToAnswerContent = CommentToAnswerContent,
                QuestionId = questionId,
                AppUserId = appUserId
            };
        }

    }
}
