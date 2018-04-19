using BoardEnvy.Domain.Enums;

namespace BoardEnvy.Domain.Models
{
    public class UserStory
    {
        public int BoardId
        {
            get;
            set;
        }

        public long UserStoryId
        {
            get;
            set;
        }

        public string Summary
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public StoryStatus Status { get; set; }
    }
}
