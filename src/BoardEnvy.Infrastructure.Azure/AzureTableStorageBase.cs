
namespace BoardEnvy.Infrastructure.Azure
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Table;

    public abstract class AzureTableStorageBase
    {
        private readonly CloudTableClient _tableClient;

        public AzureTableStorageBase(IConfiguration configuration)
        {
            var cloudStorageAccount = CloudStorageAccount.Parse(configuration["StorageConnectionString"]);
            _tableClient = cloudStorageAccount.CreateCloudTableClient();
        }

        protected CloudTable GetTableReference(string tableName)
        {
            var table = _tableClient.GetTableReference(tableName);
            table.CreateIfNotExistsAsync().Wait();

            return table;
        }
    }
}
