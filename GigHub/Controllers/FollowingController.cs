using GigHub.DTO;
using GigHub.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GigHub.Controllers
{
    [Authorize]
    public class FollowingController : ApiController
    {
        private ApplicationDbContext _context;

        public FollowingController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Follow(FollowingDTO dto)
        {
            var userId = User.Identity.GetUserId(); //GET USERIS
                                                    //CHECK EXSISTS 

            if (_context.Followings.Any(f => f.FolloweeId == userId && f.FolloweeId==dto.FolloweeId))
                return BadRequest("The attendance alreday exsist!");

            var following = new Following
            {
                FollowerId = userId,
                FolloweeId = dto.FolloweeId
            };
            _context.Followings.Add(following);
            _context.SaveChanges();
            return OK();
        }

        private IHttpActionResult OK()
        {
            throw new NotImplementedException();
        }
    }
}

