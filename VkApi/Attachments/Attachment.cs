using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OkMuay.Vkontakte
{
	public class VkAttachment
	{
		public virtual string Type { get; set; }
		public string Id { get; set; }
		public virtual VkAttachment Create(Dictionary<string,object> json){ return null; }
		public virtual string Render(){ return null; }
	}
}