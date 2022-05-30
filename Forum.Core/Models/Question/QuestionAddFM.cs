using System.ComponentModel.DataAnnotations;
using QuestionC = Forum.Domain.Models.Question;
namespace Forum.Core.Models.Question
{
    public class QuestionAddFM
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string QuestionContent { get; set; }
        [Required]
        public int AppUserId { get; set; }


        public QuestionC Construct(int appUserId)
        {
            return new QuestionC()
            {
                Title = this.Title,
                QuestionContent = this.QuestionContent,
                AppUserId = appUserId,
            };
        }

        public void changeQuestionData(QuestionC quesiton)
        {
            quesiton.Title = Title;
            quesiton.QuestionContent = QuestionContent;
        }
    }

}