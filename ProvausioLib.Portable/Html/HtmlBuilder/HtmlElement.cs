using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProvausioLib.Portable.Html.HtmlBuilder
{
    /// <summary>
    /// Represents an HTML DOM element
    /// </summary>
    public class HtmlElement
    {
        private readonly string _content;
        private readonly HtmlTag _tag;
        private readonly List<KeyValuePair<string, string>> _attributes;
        private readonly StringBuilder _element;

        private List<HtmlElement> Children { get; } = new List<HtmlElement>();

        /// <summary>
        /// Gets the type of the element.
        /// </summary>
        /// <value>
        /// The type of the element.
        /// </value>
        public HtmlTagType ElementType { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="HtmlElement"/> class.
        /// </summary>
        /// <param name="tag">The tag.</param>
        public HtmlElement(HtmlTag tag)
            : this(tag, string.Empty)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HtmlElement"/> class.
        /// </summary>
        /// <param name="tag">The tag.</param>
        /// <param name="content">The content.</param>
        public HtmlElement(HtmlTag tag, string content)
            : this(tag, content, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HtmlElement"/> class.
        /// </summary>
        /// <param name="tag">The tag.</param>
        /// <param name="content">The content.</param>
        /// <param name="attributes">The attributes.</param>
        public HtmlElement(HtmlTag tag, string content, params KeyValuePair<string, string>[] attributes)
        {
            _element = new StringBuilder();
            _tag = tag;
            _content = content;
            _attributes = attributes?.ToList() ?? new List<KeyValuePair<string, string>>();
            ElementType = _tag.TagType;
        }

        /// <summary>
        /// Adds element to this element.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns></returns>
        public HtmlElement AddChild(HtmlElement element)
        {
            Children.Add(element);
            return this;
        }

        /// <summary>
        /// Adds element to this element.
        /// </summary>
        /// <param name="tag">The tag.</param>
        /// <param name="content">The content.</param>
        /// <returns></returns>
        public HtmlElement AddChild(HtmlTag tag, string content)
        {
            Children.Add(new HtmlElement(tag, content));
            return this;
        }

        /// <summary>
        /// Adds an attribute to this element
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public HtmlElement AddAttribute(string name, string value)
        {
            _attributes.Add(new KeyValuePair<string, string>(name, value));
            return this;
        }

        /// <summary>
        /// Builds this instance.
        /// </summary>
        /// <returns></returns>
        public string Build()
        {
            // open the tag
            _element.Append(_attributes.Any() ? $"<{_tag.Tag} " : $"<{_tag.Tag}");

            // add the attributes
            foreach (var attr in _attributes)
            {
                _element.Append($"{attr.Key}=\"{attr.Value}\" ");
            }

            // insert the content
            var contentBuilder = new StringBuilder();
            foreach (var child in Children)
            {
                contentBuilder.Append(child.Build());
            }

            _element.Append($">{_content}{contentBuilder}</{_tag.Tag}>");

            return _element.ToString();
        }
    }
}