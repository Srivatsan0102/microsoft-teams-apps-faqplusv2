// <copyright file="MultipleKBCard.cs" company="Microsoft">
// Copyright (c) Microsoft. All rights reserved.
// </copyright>

namespace Microsoft.Teams.Apps.FAQPlusPlus.Cards
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using AdaptiveCards;
    using Microsoft.Azure.CognitiveServices.Knowledge.QnAMaker;
    using Microsoft.Bot.Schema;
    using Microsoft.Teams.Apps.FAQPlusPlus.Common.Models;
    using Microsoft.Teams.Apps.FAQPlusPlus.Common.Providers;

    /// <summary>
    /// Card which gives the user an option to select the KB.
    /// </summary>
    public class MultipleKBCard
    {
        private readonly IConfigurationDataProvider configurationPovider;
        private IQnAMakerClient qnaMakerClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="MultipleKBCard"/> class.
        /// </summary>
        /// <param name="configurationPovider">configurationPovider dependency injection.</param>
        /// <param name="qnAMakerClient">qnaMakerClient dependency injection.</param>
        public MultipleKBCard(IConfigurationDataProvider configurationPovider, IQnAMakerClient qnAMakerClient)
        {
            this.configurationPovider = configurationPovider;
            this.qnaMakerClient = qnAMakerClient;
        }

        /// <summary>
        /// Gets the name of the knowledgebase from QnA Maker.
        /// </summary>
        /// <param name="knowledgeBaseId">Knowledge Base ID.</param>
        /// <returns>Name of the knowledgebase.</returns>
        public async Task<string> GetKnowledgeBaseName(string knowledgeBaseId)
        {
            var knowledgebaseDetail = await this.qnaMakerClient.Knowledgebase.GetDetailsAsync(knowledgeBaseId).ConfigureAwait(false);

            string name = knowledgebaseDetail.Name;

            return name;
        }

        /*
        public string GetKBName1()
        {
            string knowledgeBaseId1 = this.configurationPovider.GetSavedEntityDetailAsync(ConfigurationEntityTypes.KnowledgeBaseId).ConfigureAwait(false).ToString();
            string name1 = this.GetKnowledgeBaseName(knowledgeBaseId1).ConfigureAwait(false).ToString();
            return name1;
        }
        public string GetKBName2()
        {
            string knowledgeBaseId2 = this.configurationPovider.GetSavedEntityDetailAsync(ConfigurationEntityTypes.KnowledgeBaseId2).ConfigureAwait(false).ToString();
            string name2 = this.GetKnowledgeBaseName(knowledgeBaseId2).ConfigureAwait(false).ToString();
            return name2;
        }*/

        /// <summary>
        /// Returns the card to select multiple knowledge bases to the user.
        /// </summary>
        /// <param name="multipleKbText">Welcome text for this card.</param>
        /// <returns>Multiple KB welcome card.</returns>
        public Attachment GetCard(string multipleKbText)
        {
            string knowledgeBaseId1 = this.configurationPovider.GetSavedEntityDetailAsync(ConfigurationEntityTypes.KnowledgeBaseId).ConfigureAwait(false).ToString();
            string name1 = this.GetKnowledgeBaseName(knowledgeBaseId1).ConfigureAwait(false).ToString();

            string knowledgeBaseId2 = this.configurationPovider.GetSavedEntityDetailAsync(ConfigurationEntityTypes.KnowledgeBaseId2).ConfigureAwait(false).ToString();
            string name2 = this.GetKnowledgeBaseName(knowledgeBaseId2).ConfigureAwait(false).ToString();

            AdaptiveCard multipleKBCard = new AdaptiveCard(new AdaptiveSchemaVersion(1, 0))
            {
                Body = new List<AdaptiveElement>
                {
                    new AdaptiveTextBlock
                    {
                        HorizontalAlignment = AdaptiveHorizontalAlignment.Left,
                        Text = multipleKbText,
                        Wrap = true,
                    },
                },
                Actions = new List<AdaptiveAction>
                {
                    new AdaptiveSubmitAction
                    {
                        Title = name1,
                        Data = new TeamsAdaptiveSubmitActionData
                        {
                            MsTeams = new CardAction
                            {
                              Type = ActionTypes.MessageBack,
                              DisplayText = "kb 1",
                              Text = "kb 1",
                            },
                        },
                    },
                    new AdaptiveSubmitAction
                    {
                        Title = name2,
                        Data = new TeamsAdaptiveSubmitActionData
                        {
                            MsTeams = new CardAction
                            {
                              Type = ActionTypes.MessageBack,
                              DisplayText = "kb 2",
                              Text = "kb 2",
                            },
                        },
                    },
                },
            };
            return new Attachment
            {
                ContentType = AdaptiveCard.ContentType,
                Content = multipleKBCard,
            };
        }
    }
}