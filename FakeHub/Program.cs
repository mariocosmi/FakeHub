using System;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Hosting;
using Owin;

namespace OwinSelfhostSample {
	public class Program {
		static void Main() {
			// string baseAddress = "http://*:8080/"; per usare questa sintassi sono necessari i privilegi di amministratore

			// Start OWIN host 
			using (WebApp.Start<Startup>(url: "http://localhost:8080")) {
				// Create HttpCient and make a request to api/values 
				//HttpClient client = new HttpClient();
				//var response = client.GetAsync(baseAddress + "api/values").Result;
				//Console.WriteLine(response);
				//Console.WriteLine(response.Content.ReadAsStringAsync().Result);

				Console.ReadLine();
			}
		}
	}
	
	public class Startup {
		// This code configures Web API. The Startup class is specified as a type
		// parameter in the WebApp.Start method.
		public void Configuration(IAppBuilder appBuilder) {
			HttpConfiguration config = new HttpConfiguration();
			config.MapHttpAttributeRoutes();
			appBuilder.UseWebApi(config);
		}
	}
}
