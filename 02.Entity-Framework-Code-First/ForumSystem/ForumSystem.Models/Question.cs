using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForumSystem.Models
{
    public class Question
    {
        private ICollection<Tag> tags;
        private ICollection<Answer> answers; 

        public Question()
        {
            this.tags = new HashSet<Tag>();
            this.answers = new HashSet<Answer>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        [ForeignKey("Author")]
        public int AuthorId { get; set; }
        public virtual User Author { get; set; }

        public virtual ICollection<Tag> Tags
        {
            get { return this.tags; }
            set { this.tags = value; }
        }

        public virtual ICollection<Answer> Answers
        {
            get { return this.answers; }
            set { this.answers = value; }
        }
    }
}