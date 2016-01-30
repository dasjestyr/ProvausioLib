namespace ProvausioLib.Portable.Html.HtmlBuilder
{
    public class HtmlTag
    {
        /// <summary>
        /// Gets the type of the tag.
        /// </summary>
        /// <value>
        /// The type of the tag.
        /// </value>
        public HtmlTagType TagType { get; }

        /// <summary>
        /// Gets the tag.
        /// </summary>
        /// <value>
        /// The tag.
        /// </value>
        public string Tag { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="HtmlTag"/> class.
        /// </summary>
        /// <param name="tagType">Type of the tag.</param>
        /// <param name="tag">The tag.</param>
        private HtmlTag(HtmlTagType tagType, string tag)
        {
            TagType = tagType;
            Tag = tag;
        }

        // definitions

        public static HtmlTag Html = new HtmlTag(HtmlTagType.Html, "html");

        public static HtmlTag Head = new HtmlTag(HtmlTagType.Head, "head");

        public static HtmlTag Title = new HtmlTag(HtmlTagType.Title, "title");

        public static HtmlTag Style = new HtmlTag(HtmlTagType.Style, "style");

        public static HtmlTag Body = new HtmlTag(HtmlTagType.Body, "body");

        public static HtmlTag Div = new HtmlTag(HtmlTagType.Div, "div");

        public static HtmlTag Paragraph = new HtmlTag(HtmlTagType.Paragraph, "p");

        public static HtmlTag Italic = new HtmlTag(HtmlTagType.Italic, "em");

        public static HtmlTag Table = new HtmlTag(HtmlTagType.Table, "table");

        public static HtmlTag TableRow = new HtmlTag(HtmlTagType.TableRow, "tr");

        public static HtmlTag TableCell = new HtmlTag(HtmlTagType.TableCell, "td");
    }
}