
namespace BoardEnvy.Infrastructure.Azure
{
    using System;
    using Microsoft.WindowsAzure.Storage.Table;

    class AzureBoard : TableEntity
    {
        public AzureBoard(Guid id, string name)
        {
            PartitionKey = "Boards";
            RowKey = id.ToString();

            Name = name;
        }

        public string Name { get; set; }

        public AzureBoard() { }
    }
}
