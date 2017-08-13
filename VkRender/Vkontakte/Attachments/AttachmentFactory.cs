using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace OkMuay.Vkontakte
{
	public static class AttachmentFactory
	{
		public static Dictionary<string, VkAttachment> AttachmentTypes; 
		public static VkAttachment CreateAttachment(string type, Dictionary<string,object> value)
		{
			return (from attType in AttachmentTypes
					where attType.Key.Equals(type, StringComparison.InvariantCultureIgnoreCase)
					select attType.Value.Create(value))
					.FirstOrDefault();
		}

		static AttachmentFactory()
		{
			AttachmentTypes = new Dictionary<string, VkAttachment>();
			Assembly assembly = Assembly.GetExecutingAssembly();
			var attTypes = assembly.GetTypes().Where(t => t.BaseType == (typeof(VkAttachment)));
			foreach (var attType in attTypes)
			{
				var typeInstance = Activator.CreateInstance(attType);
				AttachmentTypes.Add(((VkAttachment)typeInstance).Type, (VkAttachment)typeInstance);
			}
		}

	}
}