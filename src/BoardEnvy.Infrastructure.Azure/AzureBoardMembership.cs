
namespace BoardEnvy.Infrastructure.Azure
{
    using Microsoft.WindowsAzure.Storage.Table;

    class AzureBoardMembership : TableEntity
    {
        public bool Owner { get; set; }

        public string DisplayName { get; set; }

        public AzureBoardMembership(string partition, string row, string displayName, bool owner)
        {
            PartitionKey = partition;
            RowKey = row;
            DisplayName = displayName;
            Owner = owner;
        }

        public AzureBoardMembership() { }
    }
}
