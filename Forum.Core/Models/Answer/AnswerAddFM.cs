using Forum.Domain;
using System.ComponentModel.DataAnnotations;
using AnswerC = Forum.Domain.Answer;
namespace Forum.Core.Models.Answer
{
    public class AnswerAddFM
    {
        [Required]
        public string AnswerContent { get; set; }
        [Required]
        public int AppUserId { get; set; }
        [Required]
        public int QuestionId { get; set; }


        public AnswerC Construct(int questionId)
        {
            return new AnswerC()
            {
                AnswerContent = AnswerContent,
                AppUserId = AppUserId,
                QuestionId = questionId
            };
        }


    }
}
