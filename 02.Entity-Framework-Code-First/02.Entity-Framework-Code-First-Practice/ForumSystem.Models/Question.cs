using System.Collections.Generic;
using System.Data;

namespace ForumSystem.Models
{
    public class Question
    {
        private ICollection<Tag> tags; 
        public Question()
        {
            this.tags = new HashSet<Tag>();
        }
        public int Id { get; set; }
        public string Content { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public virtual User Author { get; set; }

        public virtual ICollection<Tag> Tags
        {
            get { return this.tags; }
            set { this.tags = value; }
        }

    }
}