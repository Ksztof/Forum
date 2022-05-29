using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Domain
{
    public class Question
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public int QuestionVoteUp { get; set; }
        public int QuestionVoteDown { get; set; }

        //[DataType(DataType.Text)]
        public string QuestionContent { get; set; }

        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public IEnumerable<Answer> Answers { get; set; }
        public IEnumerable<CommentToAnswer> CommentsToAnswer { get; set; }

        public IEnumerable<QuestionTag> QuestionTags { get; set; }

    }
}
