using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicRead
{
    interface ComicPage
    {
        string url { get; }

        string ImageUrl { get; }

        string AltText { get; }

        void Load();

    }
}
