namespace BoardEnvy.Domain.Models
{
    public class UserStory
    {
        public UserStory()
        {
        }

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
    }
}
