using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Web.Mvc;
using System.Web.UI;
using Microsoft.Ajax.Utilities;
using OkMuay.Vkontakte.Attachments;


namespace OkMuay.Vkontakte
{
	public class PhotoAttachment:VkAttachment
	{
		public override string Type {get { return "photo"; } }
		public string OwnerId { get; set; }
		//public string Photo130 { get; set; }
		//public string Photo604 { get; set; }
		//public DateTime Date { get; set; }

		// API lowe 5.0 

		public int Pid { get; set; }
		public int Aid { get; set; }
		public string Src { get; set; }
		public string SrcBig { get; set; }
		public string SrcSmall { get; set; }
		public string SrcXBig { get; set; }
		public string SrcXXBig { get; set; }
		public string SrcXXXBig { get; set; }
		public int Width { get; set; }
		public int Height { get; set; }
		public DateTime Created { get; set; }
		public string Text { get; set; }


		public override VkAttachment Create(Dictionary<string, object> json)
		{
			var result = new PhotoAttachment();

			try
			{
				result.Pid = int.Parse(json["pid"].ToString());
				result.Id = result.Pid.ToString();
				result.Aid = int.Parse(json["aid"].ToString());
				result.Src = json["src"].ToString();
				result.SrcBig = json.ContainsKey("src_big") ? json["src_big"].ToString() : null;
				result.SrcSmall = json.ContainsKey("src_small") ? json["src_small"].ToString() : null; 
				result.SrcXBig = json.ContainsKey("src_xbig") ?  json["src_xbig"].ToString(): null;
				result.SrcXXBig = json.ContainsKey("src_xxbig") ? json["src_xxbig"].ToString() : null;
				result.SrcXXXBig = json.ContainsKey("src_xxxbig") ? json["src_xxxbig"].ToString() : null;

				result.Height = int.Parse(json["height"].ToString());
				result.Width = int.Parse(json["width"].ToString());
				result.Text = json["text"].ToString();
				result.Created = Utilities.UnixTimeToDateTime(json["created"].ToString());
				

			}
			catch (Exception exp)
			{
				
			}

			return result;
		}

		private string GetBiggestPic()
		{
			if (!SrcXXXBig.IsNullOrWhiteSpace()) return SrcXXXBig;
			if (!SrcXXBig.IsNullOrWhiteSpace()) return SrcXXBig;
			if (!SrcXBig.IsNullOrWhiteSpace()) return SrcXBig;
			if (!SrcBig.IsNullOrWhiteSpace()) return SrcBig;
			if (!Src.IsNullOrWhiteSpace()) return Src;
			if (!SrcSmall.IsNullOrWhiteSpace()) return SrcSmall;

			return "";
		}
		public override string Render()
		{
			var result = new StringBuilder();

			result.Append("<img class='img-responsive img-thumbnail' alt='");
			result.Append(this.Text + "' ");
			result.Append(" src='");
			result.Append(GetBiggestPic()+ "' ");
			result.Append(" data-id='" + this.Id+"' />");
	
			return result.ToString();
		}
	}
}