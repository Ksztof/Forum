using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Domain
{
    public class Answer
    {
        [Key]
        public int Id { get; set; }
        public int AnswerVoteUp { get; set; }
        public int AnswerVoteDown { get; set; }

        //[DataType(DataType.Text)]
        public string AnswerContent { get; set; }

        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public int QuestionId { get; set; }
        public Question Question { get; set; }

        public IEnumerable<CommentToAnswer> CommentsToAnswer { get; set; }

    }
}
