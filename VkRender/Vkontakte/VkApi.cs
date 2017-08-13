﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Net;

namespace OkMuay.Vkontakte
{
    public class VkApi
    {
        private string mApiUrl = "https://api.vk.com/method/wall.get";
	    private string mApiVersion = "";
        public VkApi()
        {

        }

        public Wall GetWall(string userId)
        {
            string query = string.Format("{0}?owner_id={1}&v={2}", mApiUrl, userId, mApiVersion);
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