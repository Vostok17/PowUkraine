﻿using System;

namespace IdentityServer.Models
{
    public class UserVm
    {
        public string UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime BirthDay { get; set; }

        public string Role { get; set; }
    }
}
