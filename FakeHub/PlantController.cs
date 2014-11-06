using System;
using System.Collections.Generic;
using System.Web.Http;
using FakeHub;

namespace OwinSelfhostSample {
	public class PlantController : ApiController {
		[HttpPost]
		[Route("~/plant")]
		public void Post([FromBody]PlantUpdate plant) {
			Console.WriteLine("aggiornato impianto " + plant.Plant.Address);
		}
	}
}
