using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Gighub.Data;
using Gighub.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Gighub.Controllers.Api
{
    public class FollowingDto
    {
        public string FolloweeId { get; set; }
    }

    [Route("api/v{api-version:apiVersion}/[controller]")]
    [ApiController]
    [Authorize]
    public class FollowingsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public FollowingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// summary about Follow
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Follow([FromBody] FollowingDto dto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var exists = _context.Followings.Any(a => a.FollowerId == userId && a.FolloweeId == dto.FolloweeId);

            if (exists)
            {
                return BadRequest("Following already exists.");
            }

            var following = new Following
            {
                FollowerId = userId,
                FolloweeId = dto.FolloweeId
            };

            _context.Followings.Add(following);
            _context.SaveChanges();

            return Ok(JsonConvert.SerializeObject(dto));
        }

        [HttpPatch]
        public IActionResult Followx([FromBody] JsonPatchDocument<FollowingDto> dto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            //var exists = _context.Followings.Any(a => a.FollowerId == userId && a.FolloweeId == dto.FolloweeId);

            //if (exists)
            //{
            //    return BadRequest("Following already exists.");
            //}

            //var following = new Following
            //{
            //    FollowerId = userId,
            //    FolloweeId = dto.FolloweeId
            //};

            //_context.Followings.Add(following);
            //_context.SaveChanges();

            return Ok(JsonConvert.SerializeObject(dto));
        }
    }
}