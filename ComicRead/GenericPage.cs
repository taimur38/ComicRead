using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Net;

namespace ComicRead
{
    abstract class GenericPage : ComicPage
    {
        protected HtmlDocument doc;

        public void Load()
        {
            var wc = new WebClient();

            doc = new HtmlDocument();
            doc.LoadHtml(wc.DownloadString(url));
        }

        public abstract string url { get; }
        public abstract string ImageUrl { get; }
        public abstract string AltText { get; }
      
    }
}
