
namespace BoardEnvy.Domain.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using BoardEnvy.Domain.Models;

    public interface IBoardService
    {
        Task<Board> GetBoard(Guid boardId);

        Task<IEnumerable<Board>> GetAllBoards();

        Board CreateBoard(Collaborator user, string boardName);

        Task<IEnumerable<Collaborator>> GetCollaborators(Guid boardId);

        void AddCollaborator(Board board, Collaborator collaborator);
    }
}
