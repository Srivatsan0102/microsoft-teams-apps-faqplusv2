﻿// <copyright file="SearchFeedbackHelper.cs" company="Microsoft">
// Copyright (c) Microsoft. All rights reserved.
// </copyright>

namespace Microsoft.Teams.Apps.FAQPlusPlus.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web;
    using Microsoft.Bot.Schema;
    using Microsoft.Bot.Schema.Teams;
    using Microsoft.Teams.Apps.FAQPlusPlus.Cards;
    using Microsoft.Teams.Apps.FAQPlusPlus.Common.Models;
    using Microsoft.Teams.Apps.FAQPlusPlus.Common.Providers;

    /// <summary>
    /// Class that handles the search activities for messaging extension.
    /// </summary>
    public static class SearchFeedbackHelper
    {
        /// <summary>
        /// Open requests command id in the manifest file.
        /// </summary>
        private const string OpenCommandId = "openrequests";



        /// <summary>
        /// Get the results from Azure search service and populate the result (card + preview).
        /// </summary>
        /// <param name="query">Query which the user had typed in message extension search.</param>
        /// <param name="commandId">Command ID in the manifest.</param>
        /// <param name="count">Count for pagination.</param>
        /// <param name="skip">Skip for pagination.</param>
        /// <param name="localTimestamp">Local timestamp of the user activity.</param>
        /// <param name="searchService">Feedback Search service.</param>
        /// <param name="activityStorageProvider">Activity storage provider.</param>
        /// <returns><see cref="Task"/> Returns MessagingExtensionResult which will be used for providing the card.</returns>
        public static async Task<MessagingExtensionResult> GetSearchResultAsync(
            string query,
            string commandId,
            int? count,
            int? skip,
            DateTimeOffset? localTimestamp,
            IFeedbackSearchService searchService,
            IActivityStorageProvider activityStorageProvider)
        {
            MessagingExtensionResult composeExtensionResult = new MessagingExtensionResult
            {
                Type = "result",
                AttachmentLayout = AttachmentLayoutTypes.List,
                Attachments = new List<MessagingExtensionAttachment>(),
            };

            IList<FeedbackTicketEntity> searchServiceResults = new List<FeedbackTicketEntity>();
            searchServiceResults = await searchService.SearchTicketsAsync(query, count, skip).ConfigureAwait(false);
            composeExtensionResult = GetMessagingExtensionResult(localTimestamp, searchServiceResults);

            return composeExtensionResult;
        }

        /// <summary>
        /// Get populated result to in messaging extension tab.
        /// </summary>
        /// <param name="localTimestamp">Local timestamp of the user activity.</param>
        /// <param name="searchServiceResults">List of feedback tickets from Azure search service.</param>
        /// <returns><see cref="Task"/> Returns MessagingExtensionResult which will be shown in messaging extension tab.</returns>
        public static MessagingExtensionResult GetMessagingExtensionResult(
            DateTimeOffset? localTimestamp,
            IList<FeedbackTicketEntity> searchServiceResults)
        {
            MessagingExtensionResult composeExtensionResult = new MessagingExtensionResult
            {
                Type = "result",
                AttachmentLayout = AttachmentLayoutTypes.List,
                Attachments = new List<MessagingExtensionAttachment>(),
            };

            foreach (var ticket in searchServiceResults)
            {
                ThumbnailCard previewCard = new ThumbnailCard
                {
                    Title = ticket.Title,
                    Text = GetPreviewCardText(ticket, localTimestamp),
                };

                var selectedTicketAdaptiveCard = new MessagingExtensionFeedbackCard(ticket);
                composeExtensionResult.Attachments.Add(selectedTicketAdaptiveCard.ToAttachment(localTimestamp).ToMessagingExtensionAttachment(previewCard.ToAttachment()));
            }

            return composeExtensionResult;
        }

        /// <summary>
        /// Get the text for the preview card for the result.
        /// </summary>
        /// <param name="ticket">Feedback Ticket object for ask an expert action.</param>
        /// <param name="localTimestamp">Local time stamp.</param>
        /// <returns>Command id as string.</returns>
        private static string GetPreviewCardText(FeedbackTicketEntity ticket, DateTimeOffset? localTimestamp)
        {
            var cardText = $@"<div>
                                <div style='white-space:nowrap'>
                                        {HttpUtility.HtmlEncode(Cards.CardHelper.GetFormattedDateInUserTimeZone(ticket.DateCreated, localTimestamp))} 
                                        | {HttpUtility.HtmlEncode(ticket.RequesterName)}
                                </div> 
                         </div>";
            return cardText.Trim();
        }
    }
}
