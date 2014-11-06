using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeHub {
	public class Link {
		public string Rel { get; set; }
		public string Href { get; set; }
		public string Method { get; set; }
	}

	public class Root {
		public bool Working { get; set; }
		public string Credits { get; set; }
		public Link[] Links { get; set; }
	}

	public class Plant {
		public int Id { get; set; }
		public string Name { get; set; }
		public string Address { get; set; }
		public string ThumbnailUrl { get; set; }
		public int X { get; set; }
		public int Y { get; set; }
		public Queue[] Queue { get; set; }
		public Link[] Links { get; set; }
	}

	public class Queue {
		public int Id { get; set; }
		public string Descr { get; set; }
		public int Users { get; set; }
		public int Wait { get; set; }
		public Link[] Links { get; set; }
	}

	public class Ticket {
		public string Number { get; set; }
		public Plant Plant { get; set; }
		public Queue Queue { get; set; }
		public Link[] Links { get; set; }
	}

	public class PlantUpdate {
		public string TimeStamp { get; set; }
		public string Signature { get; set; }
		public Plant Plant { get; set; }
	}
}
