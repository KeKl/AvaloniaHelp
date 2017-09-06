using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using AvaloniaHelp.Core;

namespace AvaloniaHelp.Provider
{
    /// <summary>
    ///     The abstract base class for the base functionality
    ///     of content provider.
    /// </summary>
    /// <typeparam name="T">
    ///     The type of the content.
    /// </typeparam>
    public abstract class ContentProvider<T> : IContentProvider
    {
        /// <summary>
        ///     Creates a new instance of <see cref="ContentProvider"/>.
        /// </summary>
        protected ContentProvider()
        {
            TopicContent = new Dictionary<Topic, T>();
        }
        
        /// <summary>
        ///     The dictionary with the topic as key and the content
        ///     as value. Topic/Content value pairs.
        /// </summary>
        protected Dictionary<Topic, T> TopicContent { get; set; }

        public Func<IContentView> ContentViewFactory { get; set; }

        /// <summary>
        ///     Returns the content for the given topic.
        /// </summary>
        /// <param name="topic">
        ///     The topic.
        /// </param>
        /// <returns>
        ///     The content of the given topic.
        /// </returns>
        public object GetContent(Topic topic)
        {
            if (topic == null)
                return null;

            if (!TopicContent.ContainsKey(topic))
                return null;

            return TopicContent[topic];
        }

        /// <summary>
        ///     Sets the content of the given topic.
        /// </summary>
        /// <param name="topic">
        ///     The topic.
        /// </param>
        /// <param name="content">
        ///     The content of the given topic.
        /// </param>
        public void SetContent(Topic topic, T content)
        {
            Contract.Requires(topic != null);
            Contract.Requires(content != null);

            TopicContent.Add(topic, content);
        }
    }
}