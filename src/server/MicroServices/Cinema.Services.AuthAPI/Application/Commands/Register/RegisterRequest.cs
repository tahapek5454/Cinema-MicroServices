﻿using MediatR;

namespace Cinema.Services.AuthAPI.Application.Commands.Register
{
    public class RegisterRequest: IRequest<RegisterResponse>
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
