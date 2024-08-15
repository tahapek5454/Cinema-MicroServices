﻿namespace Cinema.Services.AuthAPI.Models.Dtos
{
    public class RegisterRequest
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
