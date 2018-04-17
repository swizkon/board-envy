using BoardEnvy.Domain.Enums;

namespace BoardEnvy.Domain.Models
{
    public class Task
    {
        public long TaskId
        {
            get;
            set;
        }

        public long UserStoryId
        {
            get;
            set;
        }

        public string Title
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public TaskStatus Status { get; set; }
    }
}
