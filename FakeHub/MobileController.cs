using System.Collections.Generic;
using System.Web.Http;
using FakeHub;

namespace OwinSelfhostSample {
	public class MobileController : ApiController {
		[HttpGet]
		[Route("~/v1/root")]
		public Root GetRoot() {
			return new Root {
				Working = true,
				Credits = "<H1>Viva Mario</H1>www.solari.it",
				Links = new Link[] {
					new Link { Rel = "plantsByName", Method = "GET", Href = "/v1/plants/{descr}/{nPage:int?}"},
					new Link { Rel = "plantsByPos", Method = "GET", Href = "/v1/plants/{x:int}/{y:int}/{radius:int?}"},
				}
			};
		}

		[HttpGet]
		[Route("~/v1/plants/{descr}/{nPage:int?}")]
		public IEnumerable<Plant> PerDescrizione(string descr, int nPage = 1) {
			return new Plant[] { 
				new Plant { Id = 0 + nPage * 3, Descr= "via V. Veneto 3, Udine", X = 3 + nPage * 10, Y = 4 + nPage * 10, Queue = new Queue[] {
						new Queue { Id = 1, Descr = "Servizi postali", Users = 12, Wait = 32, Links = new Link[] { new Link { Rel = "ticket", Href = "v1/plants/" + (nPage * 3) + "/ticket/1", Method = "POST" } }},
						new Queue { Id = 2, Descr = "Servizi finanziari", Users = 2, Wait = 20, Links = new Link[] { new Link { Rel = "ticket", Href = "v1/plants/" + (nPage * 3) + "/ticket/2", Method = "POST" } }},
						new Queue { Id = 3, Descr = "PostaImpresa", Users = 1, Wait = 3, Links = new Link[] { new Link { Rel = "ticket", Href = "v1/plants/" + (nPage * 3) + "/ticket/3", Method = "POST" } }},
					}, Links = new Link[] {
//						new Link { Rel = "self", Href = "v1/plant/" + (nPage * 3), Method = "GET" }
					}
				},
				new Plant { Id = 1 + nPage * 3, Descr= "via P.le Osoppo 12, Udine", X = 3 + nPage * 10, Y = 4 + nPage * 10, Queue = new Queue[] {
						new Queue { Id = 1, Descr = "Servizi postali", Users = 3, Wait = 10, Links = new Link[] { new Link { Rel = "ticket", Href = "v1/plants/" + (1 + nPage * 3) + "/ticket/1", Method = "POST" } }}, 
						new Queue { Id = 2, Descr = "Servizi finanziari", Users = 0, Wait = 0, Links = new Link[] { new Link { Rel = "ticket", Href = "v1/plants/" + (1 + nPage * 3) + "/ticket/2", Method = "POST" } }},
					}, Links = new Link[] {
//						new Link { Rel = "self", Href = "v1/plant/" + (1 + nPage * 3), Method = "GET" }
					}
				},
				new Plant { Id = 2 + nPage * 3, Descr= "S.S. 122 n. 487, Tavagnacco", X = 3 + nPage * 10, Y = 4 + nPage * 10, Queue = new Queue[] {
						new Queue { Id = 1, Descr = "Servizi postali", Users = 3, Wait = 10, Links = new Link[] { new Link { Rel = "ticket", Href = "v1/plants/" + (2 + nPage * 3) + "/ticket/2", Method = "POST" }}  },
						new Queue { Id = 2, Descr = "Servizi finanziari", Users = 4, Wait = 8, Links = new Link[] { new Link { Rel = "ticket", Href = "v1/plants/" + (2 + nPage * 3) + "/ticket/2", Method = "POST" }}  },
					}, Links = new Link[] {
//						new Link { Rel = "self", Href = "v1/plant/" + (2 + nPage * 3), Method = "GET" }
					}
				},
			};
		}

		[HttpGet]
		[Route("~/v1/plants/{x:float}/{y:float}/{radius:int?}")]
		public IEnumerable<Plant> PerPosizione(float x, float y, int radius = 100) {
			int nPage = 1;
			return new Plant[] { 
				new Plant { Id= 1, Descr= "via V. Veneto 3, Udine", X = 13, Y = 14, Queue = new Queue[] {
						new Queue { Id = 1, Descr = "Servizi postali", Users = 12, Wait = 32, Links = new Link[] { new Link { Rel = "ticket", Href = "v1/plants/" + (nPage * 3) + "/ticket/1", Method = "POST" } }},
						new Queue { Id = 2, Descr = "Servizi finanziari", Users = 2, Wait = 20, Links = new Link[] { new Link { Rel = "ticket", Href = "v1/plants/" + (nPage * 3) + "/ticket/2", Method = "POST" } }},
						new Queue { Id = 3, Descr = "PostaImpresa", Users = 1, Wait = 3, Links = new Link[] { new Link { Rel = "ticket", Href = "v1/plants/" + (nPage * 3) + "/ticket/3", Method = "POST" } }},
				}, Links = new Link[] {}},
				new Plant { Id= 2, Descr= "via P.le Osoppo 12, Udine", X = 23, Y = 24, Queue = new Queue[] {
						new Queue { Id = 1, Descr = "Servizi postali", Users = 3, Wait = 10, Links = new Link[] { new Link { Rel = "ticket", Href = "v1/plants/" + (1 + nPage * 3) + "/ticket/1", Method = "POST" } }}, 
						new Queue { Id = 2, Descr = "Servizi finanziari", Users = 0, Wait = 0, Links = new Link[] { new Link { Rel = "ticket", Href = "v1/plants/" + (1 + nPage * 3) + "/ticket/2", Method = "POST" } }},
				}, Links = new Link[] {}},
				new Plant { Id= 3, Descr= "S.S. 122 n. 487, Tavagnacco", X = 33, Y = 34, Queue = new Queue[] {
						new Queue { Id = 1, Descr = "Servizi postali", Users = 3, Wait = 10, Links = new Link[] { new Link { Rel = "ticket", Href = "v1/plants/" + (2 + nPage * 3) + "/ticket/2", Method = "POST" }}  },
						new Queue { Id = 2, Descr = "Servizi finanziari", Users = 4, Wait = 8, Links = new Link[] { new Link { Rel = "ticket", Href = "v1/plants/" + (2 + nPage * 3) + "/ticket/2", Method = "POST" }}  },
				}, Links = new Link[] {}},
			};
		}

		[HttpPost]
		[Route("~/v1/plants/{plantId:int}/ticket/{queueId:int}")]
		public Ticket EmettiTicket(int plantId, int queueId) {
			return new Ticket {
				Number = "P003",
				Plant = new Plant {
					Id = plantId, Descr = "via V. Veneto " + plantId +  ", Udine", X = 13, Y = 14
				},
				Queue = new Queue {
					Id = queueId, Descr = "Servizi postali", Users = 3, Wait = 12
				}
			};
		}

	}
}