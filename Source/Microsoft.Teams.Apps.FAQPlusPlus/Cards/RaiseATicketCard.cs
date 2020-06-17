// <copyright file="RaiseATicketCard.cs" company="Microsoft">
// Copyright (c) Microsoft. All rights reserved.
// </copyright>

namespace Microsoft.Teams.Apps.FAQPlusPlus.Cards
{
    using System;
    using System.Collections.Generic;
    using AdaptiveCards;
    using Microsoft.Bot.Schema;
    using Microsoft.Teams.Apps.FAQPlusPlus.Common.Models;
    using Microsoft.Teams.Apps.FAQPlusPlus.Properties;

    /// <summary>
    ///  The class to proivde the Raise a ticket card to give the link to service now platform.
    /// </summary>
    public static class RaiseATicketCard
    {
        /// <summary>
        /// This method will construct the card for raise a ticket bot menu.
        /// </summary>
        /// <returns>Raise a Ticket card.</returns>
        public static Attachment GetCard()
        {
            Uri uri = new Uri("http://www.tcs.com");
            string serviceNowText = $@"<a href = {uri.AbsoluteUri}> Click here to access the service now portal! </a>";
            AdaptiveCard raiseATicketCard = new AdaptiveCard(new AdaptiveSchemaVersion(1, 0))
            {
                Body = new List<AdaptiveElement>
                {
                    new AdaptiveTextBlock
                    {
                        Text = serviceNowText.Trim(),
                        Wrap = true,
                    },
                },
            };

            return new Attachment
            {
                ContentType = AdaptiveCard.ContentType,
                Content = raiseATicketCard,
            };
        }
    }
}