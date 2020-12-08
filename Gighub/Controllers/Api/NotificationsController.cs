using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Gighub.Data;
using Gighub.Models.Dtos;
using Gighub.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Gighub.Controllers.Api
{
    //public class FollowingDto
    //{
    //    public string FolloweeId { get; set; }
    //}

    [Route("api/v{api-version:apiVersion}/[controller]")]
    [ApiController]
    [Authorize]
    public class NotificationsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public NotificationsController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<NotificationDto> GetNewNotifications()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var notifications = _context.UserNotifications
                .Where(un => un.UserId == userId && un.IsRead)
                .Include(a => a.Notification.Gig.Artist)
                .Select(un => un.Notification)
                .ToList();

            //return notifications.Select(_mapper.Map<Notification, NotificationDto>);

            return _mapper.Map<List<NotificationDto>>(notifications);
        }
    }
}