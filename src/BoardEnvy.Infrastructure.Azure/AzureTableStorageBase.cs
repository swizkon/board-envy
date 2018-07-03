
namespace BoardEnvy.Infrastructure.Azure
{
    using System.Diagnostics;
    using Microsoft.Extensions.Configuration;
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Table;

    public abstract class AzureTableStorageBase
    {
        private readonly CloudTableClient _tableClient;

        public AzureTableStorageBase(IConfiguration configuration)
        {
            var connectionString = "UseDevelopmentStorage=true";
            // var connString = configuration["StorageConnectionString"];
            var cloudStorageAccount = CloudStorageAccount.Parse(connectionString);
            _tableClient = cloudStorageAccount.CreateCloudTableClient();
            Trace.WriteLine(connectionString);
        }

        protected CloudTable GetTableReference(string tableName)
        {
            var table = _tableClient.GetTableReference(tableName.ToLower());
            table.CreateIfNotExistsAsync().Wait();

            return table;
        }
    }
}
