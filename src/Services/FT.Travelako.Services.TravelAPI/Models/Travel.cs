using System.ComponentModel.DataAnnotations;

namespace FT.Travelako.Services.TravelAPI.Models
{
    public class Travel
    {
        [Key]
        public int Id { get; set; }
        public string Code { get; set; }
    }
}
