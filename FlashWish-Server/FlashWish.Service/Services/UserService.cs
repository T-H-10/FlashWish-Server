using FlashWish.Core.Entities;
using FlashWish.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashWish.Service.Services
{
    public class UserService
    {
        private readonly IRepositoryManager _repositoryManager;
        
        public UserService(IRepositoryManager repositoryManager) 
        {
            _repositoryManager = repositoryManager;
        }
        public User Add(User user)//---
        {
            _repositoryManager.Users.Add(user);
            _repositoryManager.Save();
            return user;
        }
        public void Delete(User user)
        {
            _repositoryManager.Users.Delete(user);
            _repositoryManager.Save();
        }
        public IEnumerable<User> GetAll()
        {
            var users = _repositoryManager.Users.GetAll();
            return users;
        }
        public User? GetById(int id)
        {
            return _repositoryManager.Users.GetById(id);
        }
        public User? Update(int id, User user)
        {
            var dbUser= GetById(id);
            if(dbUser == null)
            {
                return null;
            }
            //----
            _repositoryManager.Users.Update(dbUser);
            _repositoryManager.Save();
            return dbUser;
        }
    }
}
