using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Domain
{
    public class CommentToAnswer
    {
        [Key]
        public int Id { get; set; }
        public int CommentToAnswerVoteUp { get; set; }
        public int CommentToAnswerVoteDown { get; set; }
        public string CommentToAnswerContent { get; set; }

        public int AnswerId { get; set; }
        public Answer Answer { get; set; }

        public int QuestionId { get; set; } //
        public Question Question { get; set; }

        public IEnumerable<CommentToComment> Comments { get; set; }

    }
}
