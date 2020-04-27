// <copyright file="WelcomeTeamCard.cs" company="Microsoft">
// Copyright (c) Microsoft. All rights reserved.
// </copyright>

namespace Microsoft.Teams.Apps.FAQPlusPlus.Cards
{
    using System.Collections.Generic;
    using AdaptiveCards;
    using Microsoft.Bot.Schema;
    using Microsoft.Teams.Apps.FAQPlusPlus.Common;
    using Microsoft.Teams.Apps.FAQPlusPlus.Common.Models;
    using Microsoft.Teams.Apps.FAQPlusPlus.Properties;

    /// <summary>
    ///  This class process  Welcome Card when installed in a feedback team.
    /// </summary>
    public static class WelcomeFeedbackTeamCard
    {
        /// <summary>
        /// This method will construct the welcome feedback team card when bot is added to the team.
        /// </summary>
        /// <returns>Feedback Team welcome card.</returns>
        public static Attachment GetCard()
        {
            AdaptiveCard feedbackTeamWelcomeCard = new AdaptiveCard(new AdaptiveSchemaVersion(1, 0))
            {
                Body = new List<AdaptiveElement>
                {
                    new AdaptiveTextBlock
                    {
                        Text = Strings.WelcomeFeedbackTeamCardContent,
                        Wrap = true,
                    },
                },
                Actions = new List<AdaptiveAction>
                {
                    // Feedback Team- take a tour submit action.
                    new AdaptiveSubmitAction
                    {
                        Title = Strings.TakeATeamTourButtonText,
                        Data = new TeamsAdaptiveSubmitActionData
                        {
                            MsTeams = new CardAction
                            {
                                Type = ActionTypes.MessageBack,
                                DisplayText = Strings.TakeATeamTourButtonText,
                                Text = Constants.FeedbackTeamTour,
                            },
                        },
                    },
                },
            };

            return new Attachment
            {
                ContentType = AdaptiveCard.ContentType,
                Content = feedbackTeamWelcomeCard,
            };
        }
    }
}