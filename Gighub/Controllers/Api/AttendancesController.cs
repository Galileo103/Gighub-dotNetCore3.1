﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Gighub.Data;
using Gighub.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Gighub.Controllers.Api
{
    public class AttendanceDto
    {
        public int GigId { get; set; }
    }

    [Route("api/v{api-version:apiVersion}/[controller]")]
    [ApiController]
    [Authorize]
    public class AttendancesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public AttendancesController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// summary about add Attend
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Attend([FromBody] AttendanceDto dto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var exists = _context.Attendances.Any(a => a.AttendeeId == userId && a.GigId == dto.GigId);

            if (exists)
            {
                return BadRequest("The attendances already exists.");
            }

            var attendance = new Attendance
            {
                GigId = dto.GigId,
                AttendeeId = userId
            };

            _context.Attendances.Add(attendance);
            _context.SaveChanges();

            return Ok(JsonConvert.SerializeObject(dto));
        }
    }
}