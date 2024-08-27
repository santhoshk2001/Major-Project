using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using ECommerceAppDemo.API.Models;
using ECommerceAppDemo.API.Repositories;

namespace ECommerceAppDemo.API.Services
{

    public class UserService
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User GetUserById(int userId)
        {
            return _userRepository.GetUserById(userId);
        }

        public User GetUserByEmail(string email)
        {
            return _userRepository.GetUserByEmail(email);
        }

        public User GetUserByEmailAndPassword(string email, string password)
        {
            return _userRepository.GetUserByEmailAndPassword(email, password);
        }

        // Add method to get the user's UName
        public string GetUserNameByEmail(string email)
        {
            var user = _userRepository.GetUserByEmail(email);
            return user != null ? user.UName : null;
        }


        public void CreateUser(User user)
        {
            _userRepository.CreateUser(user);
        }
    }

}