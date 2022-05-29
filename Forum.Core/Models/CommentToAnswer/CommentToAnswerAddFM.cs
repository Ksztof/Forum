using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommentToAnswerC = Forum.Domain.CommentToAnswer;
namespace Forum.Core.Models.CommentToAnswer
{
    public class CommentToAnswerAddFM
    {
        [Required]
        public int AnswerId { get; set; }
        [Required]
        public string CommentToAnswerContent { get; set; }


        public CommentToAnswerC Construct(int answerId, int questionId)
        {
            return new CommentToAnswerC()
            {
                AnswerId = answerId,
                CommentToAnswerContent = CommentToAnswerContent,
                QuestionId = questionId
            };
        }

    }
}
