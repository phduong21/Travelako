namespace FT.Travelako.WebAPI.Models.GenericAPI
{
    public class GenericAPIResponse
    {
        public object? Result { get; set; }
        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; } = string.Empty; 

    }
}
