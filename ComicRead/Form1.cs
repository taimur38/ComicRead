using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using HtmlAgilityPack;

namespace ComicRead
{
    public partial class Comic : Form
    {
        IEnumerable<ComicPage> comics;
        Dictionary<string, string> OldUrls = new Dictionary<string, string>();

        Stack<string> queue = new Stack<string>();

        public Comic()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.BackColor = Color.Transparent;

            System.Reflection.Assembly asm = System.Reflection.Assembly.GetExecutingAssembly();
            comics = asm.GetTypes().Where(o => o.GetInterfaces().Contains(typeof(ComicPage)) && !o.IsAbstract).Select(a => (ComicPage)Activator.CreateInstance(a));

            foreach (var site in comics)
            {
                site.Load();
                OldUrls.Add(site.url, "");
            }   

            LoadComic();
        }

        public void LoadComic()
        {
            foreach (var page in comics)
            {
                page.Load();
                if (OldUrls[page.url] != page.ImageUrl)
                {
                    OldUrls[page.url] = page.ImageUrl;
                    queue.Push(page.ImageUrl);
                }
            }

            pictureBox1.Load(queue.Pop());
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (queue.Count > 0)
                pictureBox1.Load(queue.Pop());
            else
                this.Hide();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            LoadComic();
        }
    }
}
