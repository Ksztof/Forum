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


        public AnswerC Construct(int questionId, int appUserId)
        {
            return new AnswerC()
            {
                AnswerContent = this.AnswerContent,
                AppUserId = appUserId,
                QuestionId = questionId
            };
        }


    }
}
