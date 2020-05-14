// <copyright file="IFeedbackSearchService.cs" company="Microsoft">
// Copyright (c) Microsoft. All rights reserved.
// </copyright>

namespace Microsoft.Teams.Apps.FAQPlusPlus.Common.Providers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.Teams.Apps.FAQPlusPlus.Common.Models;

    /// <summary>
    /// Interface of Feedback Search Service provider.
    /// </summary>
    public interface IFeedbackSearchService
    {
        /// <summary>
        /// Provide search result for table to be used by feedback experts based on Azure search service.
        /// </summary>
        /// <param name="searchQuery">searchQuery to be provided by message extension.</param>
        /// <param name="count">Number of search results to return.</param>
        /// <param name="skip">Number of search results to skip.</param>
        /// <returns>List of search results.</returns>
        Task<IList<FeedbackTicketEntity>> SearchTicketsAsync(string searchQuery, int? count = null, int? skip = null);
    }
}
