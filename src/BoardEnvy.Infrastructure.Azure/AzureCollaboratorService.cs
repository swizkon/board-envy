namespace BoardEnvy.Infrastructure.Azure
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using BoardEnvy.Domain.Models;
    using Microsoft.Extensions.Configuration;
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Table;

    public class AzureCollaboratorService : AzureTableStorageBase
    {
        public AzureCollaboratorService(IConfiguration configuration)
            : base(configuration)
        {
        }

        public Board CreateBoard(string userkey, string boardName)
        {
            var membershipEntity = new AzureBoardMembership(userkey, boardName, true);
            GetTableReference("BoardMemberships")
                .ExecuteAsync(TableOperation.Insert(membershipEntity));

            var boardEntity = new AzureBoard(boardName);
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
            var query = new TableQuery<AzureBoard>()
                .Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, "Boards"));

            var boardsTable = base.GetTableReference("Boards");

            var data = await boardsTable.ExecuteQuerySegmentedAsync<AzureBoard>(query, null);
            return data.Results
                       .Select(x => new Board
                       {
                           BoardKey = x.RowKey,
                           Name = x.Name
                       });
        }
    }
}
