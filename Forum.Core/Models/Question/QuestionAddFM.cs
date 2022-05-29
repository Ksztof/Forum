using System.ComponentModel.DataAnnotations;
using QuestionC = Forum.Domain.Question;
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


        public QuestionC Construct()
        {
            return new QuestionC()
            {
                Title = Title,
                QuestionContent = QuestionContent,
                AppUserId = AppUserId
            };
        }

        public void changeQuestionData(QuestionC quesiton)
        {
            quesiton.Title = Title;
            quesiton.QuestionContent = QuestionContent;
        }
    }

}