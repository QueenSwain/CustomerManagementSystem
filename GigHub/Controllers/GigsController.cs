using GigHub.Models;
using GigHub.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace GigHub.Controllers
{
    public class GigsController : Controller
    {
        private readonly ApplicationDbContext _context; //its only initializing the constructor and we are nto using it anywhere else.

        
        public GigsController()
        {
            _context = new ApplicationDbContext();
        }

        [Authorize]
        public ActionResult Attending()
        {
            var UserId = User.Identity.GetUserId();
            var gigs = _context.Attendances.
                Where(a=>a.AttendeeId==UserId)
                .Select(a=>a.Gig)
                .Include(g=>g.Artist)
                .Include(g=>g.Genre)
                .ToList();
            var viewModel = new GigsViewModel
            {
                UpcomingGigs = gigs,
                ShowActions = User.Identity.IsAuthenticated,
                Heading="Gigs I'm attending"
            };

            return View("Gigs",viewModel);
        }


        // GET: Gigs
        [Authorize]      //by usign autorize its performing default (ApplicationUser) login actions
        public ActionResult Create()
        {
           
            //get the data from db
            var viewModel = new GigFormViewModel
            {
                Genres = _context.Genres.ToList()
            };
            return View(viewModel);
        }
        [Authorize]
        [HttpPost]
      [ValidateAntiForgeryToken]
        public ActionResult Create(GigFormViewModel viewModel)
        {
            //var artistId = User.Identity.GetUserId();
            //var artist = _context.Users.Single(u => u.Id == artistId);
            //var genre = _context.Genres.Single(g => g.Id == viewModel.Genre);
            //var gig = new Gig
            //{
            //    Artist = artist,//application object
            //    DateTime=DateTime.Parse(string.Format("{0} {1}",viewModel.Date,viewModel.Time)),
            //    Genre=genre,
            //    Venue=viewModel.Venue

            //};

            //in place of this code we have added foreign ky to gig

            if (!ModelState.IsValid) //if not valid
            {
                viewModel.Genres = _context.Genres.ToList();//Intializing genres or else it will show null error
                return View("Create", viewModel);
            }
                
                var gig = new Gig
            {
                ArtistId = User.Identity.GetUserId(),//application object
                DateTime = viewModel.GetDateTime(),
                GenreId = viewModel.Genre,
                Venue = viewModel.Venue

            };

            _context.Gigs.Add(gig);
            _context.SaveChanges();

            return RedirectToAction("Index","Home"); //view,controller
        }

    }
}