using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Gighub.Data;
using Gighub.Models.Entities;
using Gighub.Models.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gighub.Controllers.Api
{
    [Route("api/v{api-version:apiVersion}/[controller]")]
    [ApiController]
    [Authorize]
    public class GigsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public GigsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Cancle([FromRoute]int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var gig = _context.Gigs.Single(g => g.Id == id && g.ArtistId == userId);

            if (gig.IsCanceled)
            {
                return NotFound();
            }

            gig.IsCanceled = true;

            var notification = new Notification
            {
                DateTime = DateTime.Now,
                NotificationType = NotificationType.GigCanceled,
                GigId = gig.Id
            };

            var attendess = _context.Attendances.Where(a => a.GigId == gig.Id)
                .Select(a => a.Attendee)
                .ToList();

            foreach (var attendee in attendess)
            {
                var userNotification = new UserNotification
                {
                    User = attendee,
                    Notification = notification
                };

                _context.UserNotifications.Add(userNotification);
            }

            _context.SaveChanges();

            return Ok();
        }

    }
}