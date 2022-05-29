using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Domain
{
    public class CommentToComment
    {
        [Key]
        public int Id { get; set; }
        public string CommentToCommentContent { get; set; }
        public int CommentToCommentVoteUp { get; set; }
        public int CommentToCommentVoteDown { get; set; }
        public int CommentToAnswerId { get; set; }
        public CommentToAnswer CommentToAnswer { get; set; }
    }
}
