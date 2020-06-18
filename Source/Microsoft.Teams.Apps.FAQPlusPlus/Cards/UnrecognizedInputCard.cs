// <copyright file="UnrecognizedInputCard.cs" company="Microsoft">
// Copyright (c) Microsoft. All rights reserved.
// </copyright>

namespace Microsoft.Teams.Apps.FAQPlusPlus.Cards
{
    using System;
    using System.Collections.Generic;
    using AdaptiveCards;
    using Microsoft.Bot.Schema;
    using Microsoft.Teams.Apps.FAQPlusPlus.Common;
    using Microsoft.Teams.Apps.FAQPlusPlus.Common.Models;
    using Microsoft.Teams.Apps.FAQPlusPlus.Properties;

    /// <summary>
    ///  This class handles unrecognized input sent by the user-asking random question to bot.
    /// </summary>
    public static class UnrecognizedInputCard
    {
        /// <summary>
        /// This method will construct the card when unrecognized input is sent by the user.
        /// </summary>
        /// <param name="userQuestion">Actual question asked by the user to the bot.</param>
        /// <returns>UnrecognizedInput Card.</returns>
        public static Attachment GetCard(string userQuestion)
        {
            Uri uri = new Uri("http://www.tcs.com");
            AdaptiveCard unrecognizedInputCard = new AdaptiveCard(new AdaptiveSchemaVersion(1, 0))
            {
                Body = new List<AdaptiveElement>
                {
                    new AdaptiveTextBlock
                    {
                        Text = "I didn't find a matching answer for this question. Do you want to raise a ticket?",
                        Wrap = true,
                    },
                },
                Actions = new List<AdaptiveAction>
                {
                         new AdaptiveOpenUrlAction
                    {
                        Title = "Service Now Portal",
                        Url = uri,
                    },
                },
            };

            return new Attachment
            {
                ContentType = AdaptiveCard.ContentType,
                Content = unrecognizedInputCard,
            };
        }
    }
}