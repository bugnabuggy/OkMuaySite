using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OkMuay.Vkontakte.Attachments
{
	public static class Utilities
	{
		public static DateTime UnixTimeToDateTime(string unixtime)
		{
			long timestamp = long.Parse(unixtime);
			var origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
			var date = origin.AddSeconds(timestamp);

			return date;
		}
	}
}