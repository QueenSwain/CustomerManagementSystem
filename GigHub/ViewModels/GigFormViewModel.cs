using GigHub.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GigHub.ViewModels
{
    public class GigFormViewModel
    {
        [Required]
        public string Venue { get; set; }

        [Required]
        [FutureDate]
        public string Date { get; set; }

        [Required]
        [ValidTime]
        public string Time { get; set; }

        [Required]
        public byte Genre { get; set; }

        public IEnumerable<Genre> Genres { get; set; } //using Genre class from Model folder

      
      /* As per the condition it should not throw error.
      * when the model state isnot valid still its coming to GigFormViewModel and its showing error.
      * Because all properties inspects httprequest nad it needs a value fro each key.inorder to solve this we made it a method 
      *  public DateTime DateTime  
         {
            get
            { return DateTime.Parse(string.Format("{0} {1}", Date, Time)); }
        } */
        public DateTime GetDateTime()
        {
            { return DateTime.Parse(string.Format("{0} {1}", Date, Time)); }
        }

    }
}
 