namespace BoardEnvy.Infrastructure.Azure
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using BoardEnvy.Domain.Models;
    using BoardEnvy.Domain.Interfaces;
    using Microsoft.Extensions.Configuration;
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Table;
    using System.Diagnostics;

    public class AzureCollaboratorService : AzureTableStorageBase, IBoardService
    {
        public AzureCollaboratorService(IConfiguration configuration)
            : base(configuration)
        {
        }

        public Board CreateBoard(Collaborator user, string boardName)
        {
            var boardId = Guid.NewGuid();
            
            var memberships = GetTableReference("Memberships");
            
            var userEntry = new AzureBoardMembership("user-" + user.UserKey, "board-" + boardId.ToString(), boardName, true);
            memberships.ExecuteAsync(TableOperation.Insert(userEntry));
            var boardEntry = new AzureBoardMembership("board-" + boardId.ToString(), "user-" + user.UserKey, user.DisplayName, true);
            memberships.ExecuteAsync(TableOperation.Insert(boardEntry));

            var boardEntity = new AzureBoard(boardId, boardName);
            GetTableReference("Boards")
                .ExecuteAsync(TableOperation.Insert(boardEntity));

            return new Board
            {
                Name = boardName,
                BoardKey = boardEntity.RowKey
            };
        }

        public async Task<IEnumerable<Board>> GetAllBoards()
        {
            var q = TableQuery.GenerateFilterCondition("", QueryComparisons.Equal, "");
            var query = new TableQuery<AzureBoard>();
            // .Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, "boards"));

            var boardsTable = base.GetTableReference("Boards");

            var data = await boardsTable.ExecuteQuerySegmentedAsync<AzureBoard>(query, null);
            return data.Results
                       .Select(x => new Board
                       {
                           BoardKey = x.RowKey,
                           Name = x.Name
                       });
        }

        public async Task<Board> GetBoard(Guid id)
        {
            var table = base.GetTableReference("boards");

            var retrieveOperation = TableOperation.Retrieve<AzureBoard>("boards", id.ToString());

            var retrievedResult = await table.ExecuteAsync(retrieveOperation);

            if (retrievedResult.Result != null)
            {
                var med = (AzureBoard) retrievedResult.Result;
                return new Board
                {
                    BoardKey = med.RowKey,
                    Name = med.Name
                };
            }

            return null;
        }

        public void AddCollaborator(Board board, Collaborator collaborator)
		{
            var memberships = GetTableReference("memberships");

            var userEntry = new AzureBoardMembership("user-" + collaborator.UserKey, "board-" + board.BoardKey, board.Name, false);
            memberships.ExecuteAsync(TableOperation.Insert(userEntry));

            var boardEntry = new AzureBoardMembership("board-" + board.BoardKey, "user-" + collaborator.UserKey, collaborator.DisplayName, false);
            memberships.ExecuteAsync(TableOperation.Insert(boardEntry));
		}

		public async Task<IEnumerable<Board>> GetBoardsForUser(string userkey)
        {
            var query = new TableQuery<AzureBoardMembership>()
                // .Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, "user-" + userkey));
                .Where(TableQuery.GenerateFilterCondition("ListName", QueryComparisons.Equal, "user-" + userkey));

            var boardsTable = base.GetTableReference("memberships");

            var data = await boardsTable.ExecuteQuerySegmentedAsync<AzureBoardMembership>(query, null);
            return data.Results
                       .Select(x => new Board
                       {
                           BoardKey = x.RowKey.Replace("board-", ""),
                           Name = x.DisplayName
                       });
        }

        public async Task<IEnumerable<Collaborator>> GetCollaborators(Guid boardId)
        {
            var query = new TableQuery<AzureBoardMembership>()
                // .Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, "board-" + boardId.ToString()));
                .Where(TableQuery.GenerateFilterCondition("ListName", QueryComparisons.Equal, "board-" + boardId.ToString()));
                //.Replace("'", "\""));
                // .Where(TableQuery.GenerateFilterCondition("ListName", QueryComparisons.Equal, "user-" + userkey));
                

            Trace.WriteLine(query.FilterString);

            var boardsTable = base.GetTableReference("memberships");

            var data = await boardsTable.ExecuteQuerySegmentedAsync<AzureBoardMembership>(query, null);
            return data.Results.Select(x => new Collaborator(x.RowKey.Replace("user-", ""), x.DisplayName));
        }
    }
}
