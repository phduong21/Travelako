using FT.Travelako.Common.BaseModels;
using FT.Travelako.UI.Models.Authentication;
using FT.Travelako.UI.Models.Users;
using FT.Travelako.UI.Models.Users.ViewModel;

namespace FT.Travelako.UI.Services
{
    public interface IUserService
    {
        Task<UserDetailResponseModel> GetUserInformationById(string userId);
        Task<IEnumerable<UserDetailResponseModel>> GetAllUsers();
        Task<IEnumerable<UserDetailResponseModel>> GetAllBusinessUsers();
        Task<UserDetailResponseModel> CreateUser(SignUpVM model);
        Task<UserDetailResponseModel> UpdateUser(UpdateUserModel model);
        Task<bool> DeleteUser(string userId);
        Task<PersonalizeModel> GetPersonalizeUser(string userId);
        Task UpdatePersonalizeUser(PersonalizeModel model);
        UserModel GetCurrentUser();


    }
}
