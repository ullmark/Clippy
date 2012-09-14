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

			JsonSerializerFunc = () => JsonConvert.SerializeObject(this.Data, Formatting.None, SerializationSettings);
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

			var json = JsonSerializerFunc();
			response.Write(json);

			if (!string.IsNullOrWhiteSpace(callback))
			{
				response.Write(");");
			}	
		}

		/// <summary>
		/// Gets or sets the function that produces the json string that are written
		/// to the response. Set this if you want to control the serialization process 
		/// entirely.
		/// </summary>
		public virtual Func<string> JsonSerializerFunc { get; set; }

		/// <summary>
		/// Gets or sets the Data to be rendered
		/// </summary>
		public virtual object Data { get; set; }

		/// <summary>
		/// Gets or sets the Serialization Settings
		/// </summary>
		public virtual JsonSerializerSettings SerializationSettings { get; set; }
	}
}
