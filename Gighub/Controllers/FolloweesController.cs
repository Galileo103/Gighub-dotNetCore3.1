using Gighub.Data;
using Gighub.Models.Entities;
using Gighub.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Gighub.Controllers
{
    //[Route("api/v{api-version:apiVersion}/[controller]")]
    //[ApiController]
    public class FolloweesController : Controller
    {
        private readonly ApplicationDbContext _context;
        public FolloweesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize]
        public ActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var artists = _context.Followings
                .Where(a => a.FollowerId == userId)
                .Select(f => f.Followee)
                .ToList();

            return View(artists);
        }
    }
}