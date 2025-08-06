using System;
using System.Security.Claims;

namespace Prism.Application.Auth.Interfaces;

public interface ILoginService
{
    Task<ClaimsPrincipal?> Authenticate(string email, string password);
}
