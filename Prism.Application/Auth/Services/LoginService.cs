using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Prism.Application.Auth.Interfaces;
using Prism.Infrastructure.Data;

namespace Prism.Application.Auth.Services;

public class LoginService(AppDbContext appDbContext) : ILoginService
{
    public async Task<ClaimsPrincipal?> Authenticate(string email, string password)
    {
        var user = await appDbContext
            .Users.Where(x => x.Email == email && !x.IsBlocked)
            .AsNoTracking()
            .AsSplitQuery()
            .FirstOrDefaultAsync();

        if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.Password))
            return null;

        var claimsIdenty = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
        claimsIdenty.AddClaim(new Claim(ClaimTypes.Sid, user.Id.ToString()));
        claimsIdenty.AddClaim(new Claim(ClaimTypes.Name, user.Name));
        claimsIdenty.AddClaim(new Claim(ClaimTypes.Email, user.Email));
        claimsIdenty.AddClaim(new Claim(ClaimTypes.UserData, user.Email));

        return new ClaimsPrincipal(claimsIdenty);
    }
}
