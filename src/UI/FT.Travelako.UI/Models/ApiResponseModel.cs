namespace FT.Travelako.UI.Models
{
	public class BaseApiResponseModel<T>
	{
        public T Result { get; set; }

        public bool IsSuccess { get; init; }

        public string Message { get; set; }

        public string[] Errors { get; init; }
    }
}
