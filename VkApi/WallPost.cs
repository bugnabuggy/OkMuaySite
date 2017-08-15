using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OkMuay.Vkontakte
{
    public class WallPost
    {
        public string Id { get; set; }

        public DateTime Date { get; set; }

        public string Text { get; set; }
		public string Type { get; set; }

        public List<VkAttachment> Attachmets { get; set; }

        public WallPost()
        {
            Attachmets = new List<VkAttachment>();
        }
    }
}