// <copyright file="ConfigurationEntityTypes.cs" company="Microsoft">
// Copyright (c) Microsoft. All rights reserved.
// </copyright>
namespace Microsoft.Teams.Apps.FAQPlusPlus.Common.Models
{
    /// <summary>
    /// Configuration entity type names.
    /// </summary>
    public static class ConfigurationEntityTypes
    {
        /// <summary>
        /// Team entity.
        /// </summary>
        public const string TeamId = "TeamId";

        /// <summary>
        /// Team entity.
        /// </summary>
        public const string FeedbackTeamId = "FeedbackTeamId";

        /// <summary>
        /// Knowledge base entity.
        /// </summary>
        public const string KnowledgeBaseId = "KnowledgeBaseId";

        /// <summary>
        /// Second knowledge base entity.
        /// </summary>
        public const string KnowledgeBaseId2 = "KnowledgeBaseId2";

        ///<summary>
        /// Main knowledge base.
        /// </summary>
        public const string MainKnowledgeBase = "MainKnowledgeBase";

        /// <summary>
        /// Welcome message entity.
        /// </summary>
        public const string WelcomeMessageText = "WelcomeMessageText";

        /// <summary>
        /// Help tab text entity.
        /// </summary>
        public const string HelpTabText = "HelpTabText";

        /// <summary>
        /// QnaMaker endpoint key entity.
        /// </summary>
        public const string QnAMakerEndpointKey = "QnaMakerEndpointKey";
    }
}
