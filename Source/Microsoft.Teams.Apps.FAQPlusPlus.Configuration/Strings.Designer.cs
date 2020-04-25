﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Microsoft.Teams.Apps.FAQPlusPlus.Configuration {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Strings {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Strings() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Microsoft.Teams.Apps.FAQPlusPlus.Configuration.Strings", typeof(Strings).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Hi, I&apos;m your friendly Q&amp;A bot. You can ask me questions, and I&apos;ll do my best to answer. If I can&apos;t help, I&apos;ll connect you to an expert.
        ///
        ///My key features:
        ///
        ///* Ask a question, get an answer
        ///* Ask an expert
        ///* Share feedback.
        /// </summary>
        public static string DefaultHelpTabText {
            get {
                return ResourceManager.GetString("DefaultHelpTabText", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Hi, I&apos;m your friendly Q&amp;A bot. You can ask me questions, and I&apos;ll do my best to answer. If I can&apos;t help, I&apos;ll connect you to an expert.
        ///
        ///You can ask the following questions:
        ///* How do you work?
        ///* Which benefits are available?
        ///* What things are available here right now?.
        /// </summary>
        public static string DefaultWelcomeMessage {
            get {
                return ResourceManager.GetString("DefaultWelcomeMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Provide a feedback team id deeplink which will be used by bot and then click on Ok to add or Edit to modify.
        /// </summary>
        public static string FeedbackTeamIdToolTipHoverMessage {
            get {
                return ResourceManager.GetString("FeedbackTeamIdToolTipHoverMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Provide text which will be displayed in Help tab of the bot and then click on Ok to add or Edit to modify.
        /// </summary>
        public static string HelpTabTextToolTipHoverMessage {
            get {
                return ResourceManager.GetString("HelpTabTextToolTipHoverMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Provide a valid knowledgebase id which will be used by bot and then click on Ok to add or Edit to modify.
        /// </summary>
        public static string KnowledgeBaseToolTipHoverMessage {
            get {
                return ResourceManager.GetString("KnowledgeBaseToolTipHoverMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Provide a team id deeplink which will be used by bot and then click on Ok to add or Edit to modify.
        /// </summary>
        public static string TeamIdToolTipHoverMessage {
            get {
                return ResourceManager.GetString("TeamIdToolTipHoverMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Provide a welcome message which will be used by bot and then click on Ok to add or Edit to modify.
        /// </summary>
        public static string WelcomeMessageToolTipHoverMessage {
            get {
                return ResourceManager.GetString("WelcomeMessageToolTipHoverMessage", resourceCulture);
            }
        }
    }
}
