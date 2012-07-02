using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Clippy.Mvc.ActionResults
{
	public class JsonOrJsonpResult : ActionResult
	{
		public JsonOrJsonpResult()
		{
			SerializationSettings = new JsonSerializerSettings
			{
				NullValueHandling = NullValueHandling.Ignore,
				ContractResolver = new CamelCasePropertyNamesContractResolver()
			};
		}

		public override void ExecuteResult(ControllerContext context)
		{
			var request = context.HttpContext.Request;
			var response = context.HttpContext.Response;
			response.ContentType = "application/json";

			var callback = request.Params["callback"];
			if (!string.IsNullOrWhiteSpace(callback))
			{
				response.ContentType = "application/javascript";
				response.Write(string.Concat(callback, "("));
			}

			if (this.Data != null)
			{
				var json = JsonConvert.SerializeObject(this.Data, Formatting.None, SerializationSettings);
				response.Write(json);
			}

			if (!string.IsNullOrWhiteSpace(callback))
			{
				response.Write(");");
			}	
		}

		public virtual object Data { get; set; }
		public virtual JsonSerializerSettings SerializationSettings { get; set; }
	}
}
