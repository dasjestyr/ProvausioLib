using System;
using System.Collections.Generic;

namespace ProvausioLib.Portable.Html.HtmlBuilder
{
    /// <summary>
    /// Represents the HTML root element.
    /// </summary>
    public class HtmlRoot
    {
        private KeyValuePair<string, string>[] _attributes;

        /// <summary>
        /// Gets the head element.
        /// </summary>
        /// <value>
        /// The head.
        /// </value>
        public HtmlElement Head { get; }

        /// <summary>
        /// Gets the body element.
        /// </summary>
        /// <value>
        /// The body.
        /// </value>
        public HtmlElement Body { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="HtmlRoot"/> class.
        /// </summary>
        /// <param name="head">The head.</param>
        /// <param name="body">The body.</param>
        /// <exception cref="System.ArgumentException">
        /// Head must be of type HtmlTag.Head
        /// or
        /// Body must be of type HtmlTagType.Body
        /// </exception>
        public HtmlRoot(HtmlElement head,  HtmlElement body)
        {
            Head = head;
            Body = body;
            if(head.ElementType != HtmlTagType.Head)
                throw new ArgumentException("Head must be of type HtmlTag.Head");

            if(body.ElementType != HtmlTagType.Body)
                throw new ArgumentException("Body must be of type HtmlTagType.Body");
        }

        /// <summary>
        /// Sets the attributes on the HTML element
        /// </summary>
        /// <param name="attributes">The attributes.</param>
        public void SetAttributes(params KeyValuePair<string, string>[] attributes)
        {
            _attributes = attributes;
        }

        /// <summary>
        /// Builds this instance.
        /// </summary>
        /// <returns></returns>
        public string Build()
        {
            var html = new HtmlElement(HtmlTag.Html, Head.Build() + Body.Build(), _attributes);
            return html.Build();
        }
    }
}