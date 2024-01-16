namespace FT.Travelako.UI.Models.Travels
{
	public class TravelDetailResponseModel
	{
		public string title { get; set; }
		public string description { get; set; }
		public string thumbnail { get; set; }
		public string images { get; set; }
		public string content { get; set; }
		public string province { get; set; }
		public string location { get; set; }
		public string tag { get; set; }
		public int status { get; set; }
		public string hotelTitle { get; set; }
		public string hotelPrice { get; set; }
		public int trafficType { get; set; }
		public string id { get; set; }
		public string createdBy { get; set; }
		public DateTime createdDate { get; set; }
		public string lastModifiedBy { get; set; }
		public object lastModifiedDate { get; set; }
	}

	public class TravelListingResponseModel : BaseApiResponseModel
	{
		public List<TravelDetailResponseModel> result { get; set; }
	}

	//public class TravelResponseModel : BaseApiResponseModel
	//{
	//	public TravelDetailResponseModel result { get; set; }
	//}
}
