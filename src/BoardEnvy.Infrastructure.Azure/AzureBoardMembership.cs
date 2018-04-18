
namespace BoardEnvy.Infrastructure.Azure
{
    using Microsoft.WindowsAzure.Storage.Table;

    internal class AzureBoardMembership : TableEntity
    {
        public bool Owner { get; set; }

        public AzureBoardMembership(string userkey, string boardName, bool owner)
        {
            PartitionKey = userkey;
            RowKey = boardName;
            Owner = owner;
        }

        public AzureBoardMembership() { }
    }
}
