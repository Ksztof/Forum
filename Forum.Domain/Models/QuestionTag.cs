using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Domain.Models
{
    public class QuestionTag
    {

        //Dawać virtual czy nie dawać

        public int QuestionId { get; set; }
        public virtual Question Question { get; set; }

        public int TagId { get; set; }
        public virtual Tag Tag { get; set; }

    }
}
