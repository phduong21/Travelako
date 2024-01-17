using FT.Travelako.Common.BaseModels;
using FT.Travelako.UI.Models.Authentication;
using FT.Travelako.UI.Models.Users;

namespace FT.Travelako.UI.Services
{
    public interface IUserService
    {
        Task<UserDetailResponseModel> GetUserInformation(string userName);
        Task<UserDetailResponseModel> GetUserInformationById(string userId);
        Task<IEnumerable<UserDetailResponseModel>> GetAllUsers();
        Task<UserDetailResponseModel> CreateUser(CreateUserModel model);
        Task<UserDetailResponseModel> UpdateUser(UpdateUserModel model);
        Task DeleteUser(string userId);
        Task<PersonalizeModel> GetPersonalizeUser(string userId);
        Task UpdatePersonalizeUser(PersonalizeModel model);
        UserModel GetCurrentUser();


    }
}
