
using System.Collections.Generic;
using BoardEnvy.Domain.Models;

namespace BoardEnvy.Domain.Services
{
    public interface IKanboardService
    {
        IEnumerable<Board> GetBoards(string userKey);

        IEnumerable<UserStory> GetStories(Board board);
    }
}
