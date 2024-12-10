using System.Security.Claims;
using Application.Common.Interfaces;

namespace WebApi.Services;

public class CurrentUser(IHttpContextAccessor httpContextAccessor) : IUser
{
    public Guid? Id => Guid.TryParse(httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier), out var guid) ? guid : null;
}
