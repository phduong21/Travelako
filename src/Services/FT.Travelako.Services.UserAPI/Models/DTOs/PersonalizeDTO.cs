namespace FT.Travelako.Services.UserAPI.Models.DTOs
{
    public class PersonalizeDTO
    {
        public Guid Id { get; protected set; }
        public List<string>? Personalization { get; set; }
    }
}
