﻿namespace IdentityServer.Models
{
    public class UpdateUserVm
    {
        public string UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string BirthDay { get; set; }
    }
}
