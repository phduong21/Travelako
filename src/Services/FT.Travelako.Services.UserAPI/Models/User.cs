using System.ComponentModel.DataAnnotations;

namespace FT.Travelako.Services.UserAPI.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Code { get; set; }
    }
}
