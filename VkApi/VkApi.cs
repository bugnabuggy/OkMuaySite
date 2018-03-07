using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.Configuration;

namespace OkMuay.Vkontakte
{
    public class VkApi
    {
        private string mApiUrl = "https://api.vk.com/method/wall.get";
	    private string mApiVersion = WebConfigurationManager.AppSettings["vkApiVersion"]?? "4.9";
        private string mApiAccessToken = WebConfigurationManager.AppSettings["AccessToken"];
        public VkApi()
        {

        }

        public Wall GetWall(string userId)
        {
            string query = string.Format("{0}?owner_id={1}&access_token={2}&v={3}", mApiUrl, userId, mApiAccessToken, mApiVersion);
            var request = HttpWebRequest.Create(query);
            var responseData = string.Empty;
            using(var response = request.GetResponse())
            {
                var stream = response.GetResponseStream();
                using(var reader = new System.IO.StreamReader(stream))
                {
                    responseData = reader.ReadToEnd();
                }
            }
            return VkSerializer.DeserializeWall(responseData,userId);
        }
    }
}