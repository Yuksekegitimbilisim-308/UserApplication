﻿using Microsoft.EntityFrameworkCore;
using UserApplication.Entity;
using UserApplication.Repository.Repositories;
using UserApplication.Service.Abstract;

namespace UserApplication.Service.Concrete
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepo;

        public UserService(IRepository<User> userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<bool> Login(string username, string password)
        {
            var query = _userRepo.GetQueryable();
            var user = await query
                .FirstOrDefaultAsync(x => x.Username == username);

            if (user is not null && user.Password == password)
                return true;

            return false;
        }
        public async Task<User> GetById(string username)
        {
            var query =  _userRepo.GetQueryable();
           return query.FirstOrDefault(x => x.Username == username);
        }
        public async Task<User> GetById(int id)
        {
            var query = _userRepo.GetQueryable();
            return query.FirstOrDefault(x => x.Id == id);
        }
    }
}
