using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Ajax.Utilities;
using OkMuay.Vkontakte.Attachments;

namespace OkMuay.Vkontakte
{
	public class VideoAttachment : VkAttachment
	{
		public override string Type { get { return "video"; } }
		public int OwnerId { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public int Duration { get; set; }
		public string Link { get; set; }
		public string Photo130 { get; set; }
		public string Photo320 { get; set; }
		public string Photo640 { get; set; }
		public DateTime Date { get; set; }
		public int Views { get; set; }
		public string Player { get; set; }

		//my addon
		public string AccessToken { get; set; }

		// Version lower than 5
		public int Vid { get; set; }
		public string Image { get; set; }
		public string ImageMedium { get; set; }
		public string ImageBig { get; set; }

		public override VkAttachment Create(Dictionary<string, object> json)
		{
			var result = new VideoAttachment();
			try
			{
				result.Id = json["vid"].ToString();
				result.Vid = int.Parse(result.Id);
				result.OwnerId = int.Parse(json["owner_id"].ToString());
				result.Title = json["title"].ToString();
				result.Description = json["description"].ToString();
				result.Duration = int.Parse(json["duration"].ToString());
				result.Link = json.ContainsKey("link") ? json["link"].ToString():null;
				result.Image = json["image"].ToString();
				result.ImageMedium = json.ContainsKey("image_medium") ? json["image_medium"].ToString():null;
				result.ImageBig = json.ContainsKey("image_big") ? json["image_big"].ToString() : null;
				result.Player = json.ContainsKey("player") ? json["player"].ToString():null;
				result.AccessToken = json.ContainsKey("access_key") ? json["access_key"].ToString() : null;

				result.Date = Utilities.UnixTimeToDateTime(json["date"].ToString());
			}
			catch (Exception exp)
			{
				
			}

			return result;
		}

		private string GetBiggestPic()
		{
			if (!ImageBig.IsNullOrWhiteSpace()) return ImageBig;
			if (!ImageMedium.IsNullOrWhiteSpace()) return ImageMedium;
			if (!Image.IsNullOrWhiteSpace()) return Image;

			return "";
		}

		public override string Render()
		{
			var result = new StringBuilder();

			result.Append("<div class='om-content-video'");
			result.Append(" data-id='" + Vid + "' data-link='http://vk.com/video"+OwnerId+"_"+Vid+"'>");
			result.Append("<a target='_blank' href='http://vk.com/video" + OwnerId + "_" + Vid + "'>");
			result.Append("<img class='img-responsive' alt='"+Description+"'"+ " src='"+GetBiggestPic()+"' />");
			result.Append("</a>");
			result.Append("<div class='om-content-video-timing'><span class='glyphicon glyphicon-film'></span>&nbsp;");
			result.Append((int)(Duration/60) + ":" + Duration % 60);
			result.Append("</div>");
			result.Append("</div>");

			return result.ToString();

		}
	}

	
}