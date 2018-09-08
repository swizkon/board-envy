
namespace BoardEnvy.Infrastructure.Azure
{
    using Microsoft.WindowsAzure.Storage.Table;

    class AzureBoardMembership : TableEntity
    {
        public bool Owner { get; set; }

        public string DisplayName { get; set; }

        public string ListName { get; set; }

        public AzureBoardMembership(string listName, string row, string displayName, bool owner)
        {
            PartitionKey = listName;
            RowKey = row;

            ListName = listName;
            DisplayName = displayName;
            Owner = owner;
        }

        public AzureBoardMembership() { }
    }
}
