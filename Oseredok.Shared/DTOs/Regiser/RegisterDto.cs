﻿namespace Oseredok.Shared.DTOs.Regiser
{
    public class RegisterDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public string ProfileImgPath { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public DateTime DateOfBirth { get; set; }

        public DateTime RegDate { get; set; }
    }
}