using FT.Travelako.Common.BaseInterface;
using System.ComponentModel.DataAnnotations;

namespace FT.Travelako.Services.TravelAPI.Models.DTOs
{
	public class CreateTravelRequestDTO : IBaseRequestModel
	{
		[Required]
		public string Title { get; set; }

		public string Description { get; set; }

		[Required]
		public string Thumbnail { get; set; }

		public string Images { get; set; }

		[Required]
		public string Content { get; set; }

		[Required]
		public string Province { get; set; }

		[Required]
		public string Location { get; set; }

		public string Tag { get; set; }
		public int Status { get; set; }

		[Required]
		public string HotelTitle { get; set; }

		[Required]
		public string HotelPrice { get; set; }

		[Required]
		public int TrafficType { get; set; }
	}
}