using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OkMuay.Vkontakte.Attachments;


namespace OkMuay.Vkontakte
{
    public static class VkSerializer
    {
        public static Wall DeserializeWall(string data,string userId)
        {
            var wall = new Wall()
            {
	            OwnerId = int.Parse(userId)
            };
            var objectData = JsonConvert.DeserializeObject<Dictionary<string, object>>(data);
            try
            {

                var items = JsonConvert.DeserializeObject<List<object>>(objectData["response"].ToString());
                for (int i = 1; i < items.Count; i++)
                {
                    var item = items[i];
                    var post = JsonConvert.DeserializeObject<Dictionary<string, object>>(item.ToString());
                    var wallPost = new WallPost();
                    try
                    {
                        wallPost.Id = post["id"].ToString();
                        wallPost.Date = Utilities.UnixTimeToDateTime(post["date"].ToString());
                        wallPost.Text = post["text"].ToString();
                        wallPost.Type = post["post_type"].ToString();

                        var attachments = JsonConvert.DeserializeObject<List<object>>(post["attachments"].ToString());
                        foreach (var attachment in attachments)
                        {
                            var atta = JsonConvert.DeserializeObject<Dictionary<string, object>>(attachment.ToString());
                            var values =
                                JsonConvert.DeserializeObject<Dictionary<string, object>>(atta[atta["type"].ToString()]
                                    .ToString());
                            var vkAtta = AttachmentFactory.CreateAttachment(atta["type"].ToString(), values);
                            wallPost.Attachmets.Add(vkAtta);
                        }
                    }
                    catch (Exception exp)
                    {

                    }

                    wall.Posts.Add(wallPost);
                }
            }
            catch
            {
                return wall;
            }

            return wall;
        }
    }
}