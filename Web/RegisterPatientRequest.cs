﻿namespace WebApplication9.Web
{
    public class RegisterPatientRequest
    {
        // Define properties for patient registration request
        public string Image { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
