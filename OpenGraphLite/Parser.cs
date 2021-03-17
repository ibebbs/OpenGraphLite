using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace OpenGraphLite
{
    public class Parser
    {
        public static readonly Parser Default = new Parser();

        private static readonly Regex Regex = new Regex(@"\<meta(?:\s(?:(?:content=[""'](?<Content>[^""']+)[""'])|(?:property=[""'](?<Property>og:[\w\:]+)[""']))){2}", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Multiline);

        private const string HeadOpen = "<head>";
        private const string HeadClose = "</head>";
        private const string ContentGroup = "Content";
        private const string PropertyGroup = "Property";

        private string TrimToHead(string source)
        {
            var start = source.IndexOf(HeadOpen);
            var end = source.IndexOf(HeadClose);

            if (start > -1 && end > -1)
            {
                return source.Substring(start, end - start);
            }
            else
            {
                return source;
            }
        }

        public Values Parse(string source)
        {
            if (!(source.StartsWith(HeadOpen, StringComparison.OrdinalIgnoreCase) && source.EndsWith(HeadClose, StringComparison.OrdinalIgnoreCase)))
            {
                source = TrimToHead(source);
            }

            var matches = Regex.Matches(source)
                .OfType<Match>()
                .Where(match => match.Groups[PropertyGroup].Success && match.Groups[ContentGroup].Success)
                .Select(match => new Value(match.Groups[PropertyGroup].Value, match.Groups[ContentGroup].Value))
                .ToArray();

            return new Values(matches);
        }
    }
}
