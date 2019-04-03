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
    public class AttendancesController : ApiController
    {
        private ApplicationDbContext _context;
        public AttendancesController()
        {
            _context = new ApplicationDbContext();
        }
        [HttpPost]
        public IHttpActionResult Attend(AttendanceDTO dto) //api will read not read int id
        {
            var UserId = User.Identity.GetUserId(); //GET USERIS
            //CHECK EXSISTS 
         
            if (_context.Attendances.Any(a => a.AttendeeId == UserId && a.GigId == dto.GigId))
            return BadRequest("The attendance alreday exsist!");
           
            var attendance = new Attendance
            {
                GigId = dto.GigId,
                AttendeeId = User.Identity.GetUserId()
            };
            _context.Attendances.Add(attendance);
            _context.SaveChanges();
            return OK();
        }

        private IHttpActionResult OK()
        {
            throw new NotImplementedException();
        }
    }
}
