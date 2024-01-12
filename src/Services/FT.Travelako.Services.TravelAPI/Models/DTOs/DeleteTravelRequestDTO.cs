using FT.Travelako.Common.BaseInterface;
using System.ComponentModel.DataAnnotations;

namespace FT.Travelako.Services.TravelAPI.Models.DTOs
{
    public class DeleteTravelRequestDTO : IBaseRequestModel
    {
        [Required]
        public string Id { get; set; }
    }
}
