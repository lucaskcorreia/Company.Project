﻿using Company.Project.Domain.Entities;
using Company.Project.Infra.Context;
using Company.Project.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Company.Project.Infra.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly ProjectContext _context;

        public UserRepository(ProjectContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User> GetByEmail(string email)
        {
            var user = await _context.Users
                                   .Where
                                   (
                                        x =>
                                            x.Email.ToLower() == email.ToLower()
                                    )
                                    .AsNoTracking()
                                    .ToListAsync();

            return user.FirstOrDefault();
        }

        public async Task<List<User>> SearchByEmail(string email)
        {
            var allUsers = await _context.Users
                                   .Where
                                   (
                                        x =>
                                            x.Email.ToLower().Contains(email.ToLower())
                                    )
                                    .AsNoTracking()
                                    .ToListAsync();

            return allUsers;
        }

        public async Task<List<User>> SearchByName(string name)
        {
            var allUsers = await _context.Users
                                   .Where
                                   (
                                        x =>
                                            x.Name.ToLower().Contains(name.ToLower())
                                    )
                                    .AsNoTracking()
                                    .ToListAsync();

            return allUsers;
        }
    }
}
