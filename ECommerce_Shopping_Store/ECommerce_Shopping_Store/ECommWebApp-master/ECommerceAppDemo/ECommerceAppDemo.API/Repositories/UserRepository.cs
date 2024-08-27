using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using ECommerceAppDemo.API.Data;
using ECommerceAppDemo.API.Models;

namespace ECommerceAppDemo.API.Repositories
{
    public class UserRepository
    {
        private readonly ECommerceDbContext _context;

        public UserRepository(ECommerceDbContext context)
        {
            _context = context;
        }

        public User GetUserById(int userId)
        {
            return _context.Users.FirstOrDefault(u => u.UserId == userId);
        }

        public User GetUserByEmail(string email)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email);
        }

        public User GetUserByEmailAndPassword(string email, string password)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
        }

        public void CreateUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
    }
}