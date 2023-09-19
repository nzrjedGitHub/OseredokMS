﻿namespace Oseredok.Shared.DTOs.User
{
    public class UserUpdateDto
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string ProfileImgPath { get; set; }
    }
}