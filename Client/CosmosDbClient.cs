using Client.Interfaces;
using Client.Options;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Options;

namespace Client
{
    // Primary constructor expects an instance of CosmosClient and a Container
    public class CosmosDbClient(CosmosClient _cosmosClient, Container _container) : ICosmosDbClient
    {
        // This constructor handles the instantiation of CosmosClient and Container from the configuration
        public CosmosDbClient(IOptions<CosmosDbClientOptions> configuration)
            : this(
                new CosmosClient(configuration.Value.EndpointUri, configuration.Value.PrimaryKey), 
                new CosmosClient(configuration.Value.EndpointUri, configuration.Value.PrimaryKey)
                    .GetContainer(configuration.Value.DatabaseId, configuration.Value.ContainerId))
        {
        }

        public async Task AddItemAsync<T>(T item, string partitionKey)
        {
            await _container.CreateItemAsync(item, new PartitionKey(partitionKey));
        }

        public async Task<T> GetItemAsync<T>(string id, string partitionKey)
        {
            ItemResponse<T> response = await _container.ReadItemAsync<T>(id, new PartitionKey(partitionKey));
            return response.Resource;
        }

        public async Task<IEnumerable<T>> QueryItemsAsync<T>(string query)
        {
            var queryDefinition = new QueryDefinition(query);
            var queryResultSetIterator = _container.GetItemQueryIterator<T>(queryDefinition);

            List<T> results = new List<T>();
            while (queryResultSetIterator.HasMoreResults)
            {
                var currentResultSet = await queryResultSetIterator.ReadNextAsync();
                results.AddRange(currentResultSet.Resource);
            }
            return results;
        }

        public async Task ReplaceItemAsync<T>(string id, T item, string partitionKey)
        {
            await _container.ReplaceItemAsync(item, id, new PartitionKey(partitionKey));
        }

        public async Task DeleteItemAsync(string id, string partitionKey)
        {
            await _container.DeleteItemAsync<object>(id, new PartitionKey(partitionKey));
        }
    }
}
