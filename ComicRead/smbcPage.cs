using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ComicRead
{
    class smbcPage : GenericPage
    {
        public override string url { get { return "http://www.smbc-comics.com"; } }

        public override string ImageUrl { get { return Regex.Match(doc.DocumentNode.InnerHtml, @"http://www.smbc-comics.com/comics/\d+.gif").Value; } }

        public override string AltText { get { return ""; } }
    }
}
