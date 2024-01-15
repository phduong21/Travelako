namespace FT.Travelako.UI.Models
{
	public class BaseApiResponseModel
	{
		public bool isSuccess { get; set; }
		public string message { get; set; }
		public object data { get; set; }
	}
}
