
using System.Collections.Generic;
using BoardEnvy.Domain.Models;

namespace BoardEnvy.Domain.Services
{
    public interface IKanboardService
    {
        IEnumerable<Board> GetBoards(Collaborator user);

        IEnumerable<Story> GetStories(Board board);
    }
}
