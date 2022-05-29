using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnswerC = Forum.Domain.Answer;
namespace Forum.Core.Models.Answer
{
    public class AnswerUpdateFM
    {
        [Required]
        public string AnswerContent { get; set; }

        public void changeAnswerData(AnswerUpdateFM model, AnswerC answer)
        {
            answer.AnswerContent = model.AnswerContent;
        }
    }
}
