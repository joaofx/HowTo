using System.Collections.Generic;

namespace HowShop.Web.Models
{
    public class Product
    {
        public Product()
        {
            RemoteImages = new List<string>();
        }

        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Tag { get; set; }
        public string LocalThumbnail { get; set; }
        public List<string> RemoteImages { get; set; }
        public string RemoteThumbnail { get; set; }
        public bool Sold { get; set; }

        public Product WithTag(string tag)
        {
            Tag = tag;
            return this;
        }
    }
}