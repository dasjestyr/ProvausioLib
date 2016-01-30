namespace ProvausioLib.Portable.Parsing
{
    public struct ReplacementToken
    {
        /// <summary>
        /// Gets the open token, signifying the beginning of a replacement token.
        /// </summary>
        /// <value>
        /// The open token.
        /// </value>
        public string OpenToken { get; }

        /// <summary>
        /// Gets the close token, signifying the end of a replacement token.
        /// </summary>
        /// <value>
        /// The close token.
        /// </value>
        public string CloseToken { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ReplacementToken"/> struct.
        /// </summary>
        /// <param name="openToken">The open token.</param>
        /// <param name="closeToken">The close token.</param>
        public ReplacementToken(string openToken, string closeToken)
        {
            OpenToken = openToken;
            CloseToken = closeToken;
        }
    }
}