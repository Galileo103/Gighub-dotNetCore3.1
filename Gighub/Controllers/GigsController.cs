using Gighub.Data;
using Gighub.Models.Entities;
using Gighub.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Collections.Generic;

namespace Gighub.Controllers
{
    public class GigsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public GigsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize]
        public IActionResult Create()
        {
            var viewModel = new GigFormViewModel
            {
                Genres = new List<Genre>()
                {
                    new Genre {Id = 1, Name = "Jazz" },
                    new Genre {Id = 2, Name = "Blues" },
                    new Genre {Id = 3, Name = "Rock" },
                    new Genre {Id = 4, Name = "Country" }
                }
            };
            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(GigFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Genres = new List<Genre>()
                {
                    new Genre {Id = 1, Name = "Jazz" },
                    new Genre {Id = 2, Name = "Blues" },
                    new Genre {Id = 3, Name = "Rock" },
                    new Genre {Id = 4, Name = "Country" }
                };
                return View("Create", viewModel);
            }
            var gig = new Gig
            {
                ArtistId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                DateTime = viewModel.GetDateTime(),
                GenreId = viewModel.Genre,
                Venue = viewModel.Venue
            };

            _context.Gigs.Add(gig);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}