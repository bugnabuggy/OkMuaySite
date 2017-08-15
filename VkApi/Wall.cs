using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;

namespace OkMuay.Vkontakte
{
    public class Wall
    {
	    public int OwnerId { get; set; }
        public List<WallPost> Posts { get; set; }

        public Wall()
        {
            Posts = new List<WallPost>();  
        }

	    public string Render()
	    {
            string userid = "id";
            string club = "club";
		    var result = new StringBuilder();
		    foreach (var wallPost in Posts)
		    {
                string id = "";
                id = OwnerId < 0 ?  club+OwnerId * (-1) : userid+OwnerId;
			    result.Append("<div class='om-wall-post'"+"post-id="+ wallPost.Id +">");
			    result.Append("<a href='https://vk.com/"+id+"?w=wall"+ OwnerId+"_"+wallPost.Id+"' target='_blank' class='om-wall-post-header'>");
			    result.Append(wallPost.Date.ToString(new CultureInfo("ru-ru")));
			    result.Append("</a>");
				result.Append("<div class='om-wall-post-content'>");
			    result.Append(wallPost.Text);
				result.Append("</div>");
			    result.Append("<div>");
			    foreach (var atta in wallPost.Attachmets)
			    {
					if(atta != null)
						result.Append(atta.Render());
			    }
			    result.Append("</div>");
			    result.Append("</div>");
		    }


		    return result.ToString();
	    }
    }
}