﻿// <copyright file="ResponseCard.cs" company="Microsoft">
// Copyright (c) Microsoft. All rights reserved.
// </copyright>

namespace Microsoft.Teams.Apps.FAQPlusPlus.Cards
{
    using System;
    using System.Collections.Generic;
    using AdaptiveCards;
    using Microsoft.Bot.Schema;
    using Microsoft.Teams.Apps.FAQPlusPlus.Bots;
    using Microsoft.Teams.Apps.FAQPlusPlus.Common;
    using Microsoft.Teams.Apps.FAQPlusPlus.Common.Models;
    using Microsoft.Teams.Apps.FAQPlusPlus.Properties;

    /// <summary>
    ///  This class process Response Card- Response by bot when user asks a question to bot.
    /// </summary>
    public static class ResponseCard
    {
        /// <summary>
        /// Construct the response card - when user asks a question to QnA Maker through bot.
        /// </summary>
        /// <param name="question">Knowledgebase question, from QnA Maker service.</param>
        /// <param name="answer">Knowledgebase answer, from QnA Maker service.</param>
        /// <param name="userQuestion">Actual question asked by the user to the bot.</param>
        /// <returns>Response card.</returns>
        public static Attachment GetCard(string question, string answer, string userQuestion)
        {
            Uri uri = new Uri("http://www.tcs.com");

            AdaptiveCard responseCard = new AdaptiveCard(new AdaptiveSchemaVersion(1, 0))
            {
                Body = new List<AdaptiveElement>
                {
                    new AdaptiveTextBlock
                    {
                        Weight = AdaptiveTextWeight.Bolder,
                        Text = Strings.ResponseHeaderText,
                        Wrap = true,
                    },
                    new AdaptiveTextBlock
                    {
                        Text = question,
                        Wrap = true,
                    },
                    new AdaptiveTextBlock
                    {
                        Text = answer,
                        Wrap = true,
                    },
                },
                Actions = new List<AdaptiveAction>
                {
                    new AdaptiveSubmitAction
                    {
                        Title = "Raise a Ticket",
                        Data = new ResponseCardPayload
                        {
                            MsTeams = new CardAction
                            {
                                Type = ActionTypes.MessageBack,
                                DisplayText = Constants.RaiseATicket,
                                Text = Constants.RaiseATicket,
                            },
                            UserQuestion = userQuestion,
                            KnowledgeBaseAnswer = answer,
                        },
                    },
                    /*new AdaptiveOpenUrlAction
                    {
                        Title = "Raise a Ticket",
                        Url = uri,
                    },*/
                },
            };

            return new Attachment
            {
                ContentType = AdaptiveCard.ContentType,
                Content = responseCard,
            };
        }
    }
}