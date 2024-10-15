# CosmosDbClient

CosmosDbClient is a library designed to interact with Azure Cosmos DB. It provides functionalities to perform CRUD operations on Cosmos DB containers, with support for partition-based querying and item replacement.

## Table of Contents

1. [Introduction](#introduction)
2. [Features](#features)
3. [Tech Stack](#tech-stack)
4. [Usage](#usage)
5. [Configuration](#configuration)

## Introduction

CosmosDbClient provides a simple and efficient way to interact with Azure Cosmos DB. It includes support for partition-based querying and handling of Cosmos DB items, making it suitable for various scenarios in distributed systems requiring NoSQL databases.

## Features

- **Add Item:** Add an item to a specified Cosmos DB container.
- **Get Item:** Retrieve an item from a Cosmos DB container using its ID and partition key.
- **Query Items:** Execute SQL-like queries against a Cosmos DB container.
- **Replace Item:** Replace an existing item in the Cosmos DB container.
- **Delete Item:** Delete an item from the Cosmos DB container using its ID and partition key.

## Tech Stack

- **Backend:** .NET 8
- **Database:** Azure Cosmos DB
- **Dependency Injection:** Used for service registrations and configurations

## Usage

1. **Register the CosmosDbClient:** Use the `RegisterCosmosDbClient` extension method to register the client in the dependency injection container.
2. **Configure the options:** Set up `CosmosDbClientOptions` with the necessary configuration, including the endpoint URI, primary key, database ID, and container ID.
3. **Perform Operations:** Use methods such as `AddItemAsync`, `GetItemAsync`, `QueryItemsAsync`, `ReplaceItemAsync`, and `DeleteItemAsync` to interact with the Cosmos DB container.

## Configuration

### CosmosDbClientOptions

- **EndpointUri:** The URI of the Azure Cosmos DB account.
- **PrimaryKey:** The primary key for authentication with Azure Cosmos DB.
- **DatabaseId:** The ID of the Cosmos DB database.
- **ContainerId:** The ID of the Cosmos DB container.

```csharp
public class CosmosDbClientOptions
{
    public string EndpointUri { get; set; }
    public string PrimaryKey { get; set; }
    public string DatabaseId { get; set; }
    public string ContainerId { get; set; }
}
```