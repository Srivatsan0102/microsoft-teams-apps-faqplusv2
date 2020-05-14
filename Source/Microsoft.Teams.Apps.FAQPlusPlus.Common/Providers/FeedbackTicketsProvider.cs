// <copyright file="FeedbackTicketsProvider.cs" company="Microsoft">
// Copyright (c) Microsoft. All rights reserved.
// </copyright>
namespace Microsoft.Teams.Apps.FAQPlusPlus.Common.Providers
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.Teams.Apps.FAQPlusPlus.Common.Exceptions;
    using Microsoft.Teams.Apps.FAQPlusPlus.Common.Models;
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Table;

    /// <summary>
    /// Feedback Ticket provider helps in fetching and storing information in storage table.
    /// </summary>
    public class FeedbackTicketsProvider : IFeedbackTicketsProvider
    {
        private const string PartitionKey = "FeedbackTicketInfo";
        private readonly Lazy<Task> initializeTask;
        private CloudTable ticketCloudTable;

        /// <summary>
        /// Initializes a new instance of the <see cref="FeedbackTicketsProvider"/> class.
        /// </summary>
        /// <param name="connectionString">connection string of storage provided by dependency injection.</param>
        public FeedbackTicketsProvider(string connectionString)
        {
            this.initializeTask = new Lazy<Task>(() => this.InitializeTableStorageAsync(connectionString));
        }

        /// <summary>
        /// Store or update feedback ticket entity in table storage.
        /// </summary>
        /// <param name="ticket">Represents feedback ticket entity used for storage and retrieval.</param>
        /// <returns><see cref="Task"/> that represents configuration entity is saved or updated.</returns>
        public Task UpsertTicketAsync(FeedbackTicketEntity ticket)
        {
            ticket.PartitionKey = PartitionKey;
            ticket.RowKey = ticket.FeedbackTicketId;

            if (ticket.Status > (int)TicketState.MaxValue)
            {
                throw new TicketValidationException($"The ticket status ({ticket.Status}) is not valid.");
            }

            return this.StoreOrUpdateTicketEntityAsync(ticket);
        }

        /// <summary>
        /// Get already saved entity detail from storage table.
        /// </summary>
        /// <param name="ticketId">Feedback ticket id received from bot based on which appropriate row data will be fetched.</param>
        /// <returns><see cref="Task"/> Already saved entity detail.</returns>
        public async Task<FeedbackTicketEntity> GetTicketAsync(string ticketId)
        {
            await this.EnsureInitializedAsync().ConfigureAwait(false); // When there is no feedback ticket created by end user and messaging extension is open by feedback expert, table initialization is required before creating search index or datasource or indexer.
            if (string.IsNullOrEmpty(ticketId))
            {
                return null;
            }

            var searchOperation = TableOperation.Retrieve<FeedbackTicketEntity>(PartitionKey, ticketId);
            var searchResult = await this.ticketCloudTable.ExecuteAsync(searchOperation).ConfigureAwait(false);

            return (FeedbackTicketEntity)searchResult.Result;
        }

        /// <summary>
        /// Initialization of InitializeAsync method which will help in creating table.
        /// </summary>
        /// <returns>Represent a task with initialized connection data.</returns>
        private async Task EnsureInitializedAsync()
        {
            await this.initializeTask.Value.ConfigureAwait(false);
        }

        /// <summary>
        /// Create feedback tickets table if it doesn't exist.
        /// </summary>
        /// <param name="connectionString">storage account connection string.</param>
        /// <returns><see cref="Task"/> representing the asynchronous operation task which represents table is created if its not existing.</returns>
        private async Task InitializeTableStorageAsync(string connectionString)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionString);
            CloudTableClient cloudTableClient = storageAccount.CreateCloudTableClient();
            this.ticketCloudTable = cloudTableClient.GetTableReference(Constants.TicketTableName);

            await this.ticketCloudTable.CreateIfNotExistsAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// Store or update feedback ticket entity in table storage.
        /// </summary>
        /// <param name="entity">Represents feedback ticket entity used for storage and retrieval.</param>
        /// <returns><see cref="Task"/> that represents configuration entity is saved or updated.</returns>
        private async Task<TableResult> StoreOrUpdateTicketEntityAsync(FeedbackTicketEntity entity)
        {
            await this.EnsureInitializedAsync().ConfigureAwait(false);
            TableOperation addOrUpdateOperation = TableOperation.InsertOrReplace(entity);
            return await this.ticketCloudTable.ExecuteAsync(addOrUpdateOperation).ConfigureAwait(false);
        }
    }
}
