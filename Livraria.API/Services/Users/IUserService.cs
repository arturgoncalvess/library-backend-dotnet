﻿using Livraria.API.Dtos;
using Livraria.API.Models;

namespace Livraria.API.Services.Users
{
    public interface IUserService
    {
        User UserCreate(User model);

    }
}