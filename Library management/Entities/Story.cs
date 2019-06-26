using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Story
    {
        public string Title { get; set; }
        public StoryType StoryType { get; set; }
        public bool IsItOriginalStory { get; set; }
        public string AuthorName { get; set; }
    }

    public enum StoryType
    {
        Novellette,
        Novella,
        ShortStory
    }
}
