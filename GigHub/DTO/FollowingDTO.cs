﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GigHub.DTO
{
    public class FollowingDTO
    {
        public int UserId { get; set; }
        public string FolloweeId { get; set; }
    }
}