using System;
using System.Collections.Generic;
using BoardEnvy.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace BoardEnvy.Web.Controllers
{
    [Route("api/[controller]")]
    public class BoardsController : Controller
    {
        private readonly CloudTable _boardsTable;

        public BoardsController(IConfiguration configuration)
        {
            var account = CloudStorageAccount.Parse(configuration["StorageConnectionString"]);
            var tableClient = account.CreateCloudTableClient();

            _boardsTable = tableClient.GetTableReference("Boards");
            _boardsTable.CreateIfNotExistsAsync().Wait();
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<Board> Get()
        {
            return new Board[] { new Board(), new Board() };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value for " + id;
        }

        // GET api/values/5
        [HttpGet("{id}/tasks")]
        public string Tasks(int id)
        {
            return "tasks for " + id;
        }


        [HttpPost]
        public void Post([FromBody] CreateBoardModel data)
        {
            var insert = TableOperation.Insert(new AzureBoard(data.Name));
            _boardsTable.ExecuteAsync(insert);
        }
    }

    public class AzureBoard : TableEntity
    {
        public string Name { get; set; }

        public AzureBoard(string name)
        {
            PartitionKey = "Boards";
            RowKey = Guid.NewGuid().ToString();

            Name = name;
        }

        public AzureBoard() { }
    }
}
