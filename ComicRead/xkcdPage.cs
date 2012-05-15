using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using HtmlAgilityPack;

namespace ComicRead
{
    class xkcdPage : GenericPage
    {
        public override string url { get { return "http://www.xkcd.com"; } }

        public override string ImageUrl { get { return doc.DocumentNode.SelectSingleNode("//div[@id='comic']/img").Attributes["src"].Value; } }

        public override string AltText { get { return doc.DocumentNode.SelectSingleNode("//div[@id='comic']/img").Attributes["title"].Value; } }
    }
}
