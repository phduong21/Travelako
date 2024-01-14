using FT.Travelako.Common.Entities;
using System.ComponentModel.DataAnnotations;

namespace FT.Travelako.Services.TravelAPI.Models
{
    public class Travel : EntityBase
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public string Thumbnail { get; set; }
		public string Images { get; set; }
		public string Content { get; set; }
		public string Province { get; set; }
		public string Location { get; set; }
		public string Tag { get; set; }
		public int Status { get; set; }
		public string HotelTitle { get; set; }
		public string HotelPrice { get; set; }
		public int TrafficType { get; set; }
	}
}
