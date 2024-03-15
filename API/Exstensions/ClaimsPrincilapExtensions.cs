using System.Security.Claims;

namespace API.Exstensions
{
    public static class ClaimsPrincilapExtensions
    {
        public static string GetUsername(this ClaimsPrincipal user)
        {
            return user.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
    }
}
