using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Domain
{
    public class Tag
    {
        [Key]
        public int Id { get; set; } 
        public string TagName { get; set; }

        public IEnumerable<QuestionTag> QuestionTags { get; set; }
    }
}
