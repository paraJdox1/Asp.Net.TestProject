﻿using Microsoft.EntityFrameworkCore;
using ModalCRUD.Core.Data.Entities;
using ModalCRUD.Core.Data.Repositories;
using ModalCRUD.Core.Extensions;
using ModalCRUD.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModalCRUD.Infrastructure.Services
{
    internal class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> SignUpAsync(User inputUser)
        {
            var user = await _userRepository.GetByUsernameAsync(inputUser.Username);
            bool userExists = user != null;

            if (userExists) { return null!; }

            return await _userRepository.CreateAsync(inputUser);
        }

        public async Task<bool> ValidateUserAsync(User inputUser)
        {
            var user = await _userRepository.GetByUsernameAsync(inputUser.Username); // User from Db

            if (user == null) { return false; }

            var userHasValidCredentials = inputUser.Username.Equals(user.Username) &&
                                          inputUser.Password.IsEqualToThisHash(user.Password);

            if (userHasValidCredentials) { return true; }

            return false;
        }
    }
}