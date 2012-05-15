using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicRead
{
    class aspPage : GenericPage
    {
        public override string url
        {
            get { return "http://www.amazingsuperpowers.com/"; }
        }

        public override string AltText
        {
            get { return doc.DocumentNode.SelectSingleNode("//div[@class='comicpane']/img").Attributes["alt"].Value; }
        }

        public override string ImageUrl
        {
            get { return doc.DocumentNode.SelectSingleNode("//div[@class='comicpane']/img").Attributes["src"].Value; }
        }
    }
}
