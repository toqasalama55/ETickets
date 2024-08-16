﻿using Microsoft.AspNetCore.Identity;

namespace ETickets.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Address { get; set; }
    }
}
