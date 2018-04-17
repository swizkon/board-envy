
namespace BoardEnvy.Infrastructure.Azure
{
    using System;
    using System.Collections.Generic;
    using BoardEnvy.Domain.Models;
    using Microsoft.Extensions.Configuration;
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Table;

    public class AzureCollaboratorService
    {
        private readonly CloudStorageAccount _cloudStorageAccount;
        private readonly CloudTableClient _tableClient;

        public AzureCollaboratorService(IConfiguration configuration)
        {
            _cloudStorageAccount = CloudStorageAccount.Parse(configuration["StorageConnectionString"]);
            _tableClient = _cloudStorageAccount.CreateCloudTableClient();
        }

        /*
        public IList<Board> BoardsByUser(string userkey)
        {

        }
        */

        public Board CreateBoard(string userkey, string boardName)
        {
            var boardEntity = new AzureBoard(boardName);
            var insert = TableOperation.Insert(boardEntity);

            var boardsTable = _tableClient.GetTableReference("Boards");
            boardsTable.CreateIfNotExistsAsync().Wait();

            boardsTable.ExecuteAsync(insert);

            return new Board
            {
                Name = boardName,
                BoardKey = boardEntity.RowKey
            };
        }

        public IEnumerable<Board> GetAllBoards()
        {
            var query = new TableQuery<AzureBoard>();

            return new Board[] { new Board(), new Board() };
        }
    }
}
