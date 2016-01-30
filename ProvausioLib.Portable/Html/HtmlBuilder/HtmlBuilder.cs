using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace ProvausioLib.Portable.Html.HtmlBuilder
{
    public class HtmlBuilder
    {
        /// <summary>
        /// Gets the root.
        /// </summary>
        /// <value>
        /// The root.
        /// </value>
        public HtmlRoot Root { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="HtmlBuilder"/> class.
        /// </summary>
        /// <param name="root">The root.</param>
        public HtmlBuilder(HtmlRoot root)
        {
            Root = root;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HtmlBuilder"/> class.
        /// </summary>
        /// <param name="head">The head.</param>
        /// <param name="body">The body.</param>
        public HtmlBuilder(HtmlElement head, HtmlElement body)
        {
            Root = new HtmlRoot(head, body);
        }

        /// <summary>
        /// Adds to head.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns></returns>
        public HtmlBuilder AddToHead(HtmlElement element)
        {
            Root.Head.AddChild(element);
            return this;
        }

        /// <summary>
        /// Adds to body.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns></returns>
        public HtmlBuilder AddToBody(HtmlElement element)
        {
            Root.Body.AddChild(element);
            return this;
        }

        /// <summary>
        /// Sets attributes on the HTML element
        /// </summary>
        /// <param name="attributes">The attributes.</param>
        /// <returns></returns>
        public HtmlBuilder SetRootAttribute(params KeyValuePair<string, string>[] attributes)
        {
            Root.SetAttributes(attributes);
            return this;
        }

        public string Build(bool format = true)
        {
            ValidateModel();
            var result = Root.Build();

            return format
                ? XElement.Parse(result).ToString()
                : result;
        }

        private void ValidateModel()
        {
            if(Root == null)
                throw new FormatException("The DOM requires 1 html element.");

            if(Root.Head == null)
                throw new FormatException("The DOM requires 1 head element.");

            if(Root.Body == null)
                throw new FormatException("The DOM requires 1 body element.");
        }
    }
}
