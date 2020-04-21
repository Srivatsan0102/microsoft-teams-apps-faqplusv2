// <copyright file="TeamViewModel.cs" company="Microsoft">
// Copyright (c) Microsoft. All rights reserved.
// </copyright>

namespace Microsoft.Teams.Apps.FAQPlusPlus.Configuration.Models
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Represents TeamViewModel object to store team details.
    /// </summary>
    public class FeedbackTeamViewModel
    {
        /// <summary>
        /// Gets or sets team id textbox to be used in View.
        /// </summary>
        [Required(ErrorMessage = "Enter feedback team id.")]
        [MinLength(1)]
        [DataType(DataType.Text)]
        [Display(Name = "Feedback Team ID")]
        [RegularExpression(@"(\S)+", ErrorMessage = "Enter feedback team id which should not contain any whitespace.")]
        public string FeedbackTeamId { get; set; }
    }
}