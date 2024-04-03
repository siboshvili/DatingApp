using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class AdminController : BaseApiController
    {
        [Authorize(Policy = "RequireAdminRole")]
        [HttpGet("users-with-roles")]
        public ActionResult GetUsersWithRoles()
        {
            return Ok("Ony admins can see this");
        }

        [Authorize(Policy = "ModeratorPhotoRole")]
        [HttpGet("photos-to-moderate")]
        public ActionResult GetPhotosForModeratoion()
        {
            return Ok("Admins or moderators can see this ");
        }
    }
}
