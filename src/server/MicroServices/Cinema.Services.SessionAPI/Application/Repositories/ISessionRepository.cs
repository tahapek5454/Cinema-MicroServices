﻿using Cinema.Services.SessionAPI.Domain.Entities;
using SharedLibrary.Repositories;

namespace Cinema.Services.SessionAPI.Application.Repositories
{
    public interface ISessionRepository: IBaseRepository<Session>
    {
    }
}