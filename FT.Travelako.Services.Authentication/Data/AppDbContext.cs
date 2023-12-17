using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace FT.Travelako.Services.Authentication.Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {

    }
}
