
namespace BoardEnvy.Infrastructure.Azure
{
    using System;
    using Microsoft.WindowsAzure.Storage.Table;

    internal class AzureBoard : TableEntity
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
