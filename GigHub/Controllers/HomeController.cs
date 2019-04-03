using GigHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using GigHub.ViewModels;

namespace GigHub.Controllers
{
    public class HomeController : Controller
    {
        //in the index action we need to retrieve all upcoming gigs list
        private ApplicationDbContext _Context;

        public HomeController()
        {
            _Context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var UpcomingGigs = _Context.Gigs
                .Include(g=>g.Artist)
                .Include(g=>g.Genre)
                .Where(g=>g.DateTime>DateTime.Now);

            var viewModel = new GigsViewModel
            {
                UpcomingGigs = UpcomingGigs,
                ShowActions = User.Identity.IsAuthenticated,
                Heading = "Upcoming Gigs"
            };
            return View("Gigs",viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}