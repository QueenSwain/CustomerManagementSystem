using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GigHub.Models
{
    public class Gig
    {
        public int Id { get; set; }

             
        public ApplicationUser Artist { get; set; } //who is the user

        [Required] 
        public string  ArtistId { get; set; }  //type is string becaus ein applicationUser GUID which is stored as a string

        public DateTime DateTime{ get; set; }   //the action time

        [Required]
        [StringLength(255)]
        public string Venue { get; set; }     //from where

        
        public Genre Genre { get; set; } //category type

        [Required]
        public byte GenreId { get; set; }


    }
}