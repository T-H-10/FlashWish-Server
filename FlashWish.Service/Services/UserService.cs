using AutoMapper;
using FlashWish.Core.DTOs;
using FlashWish.Core.Entities;
using FlashWish.Core.IServices;
using FlashWish.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashWish.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        
        public UserService(IRepositoryManager repositoryManager, IMapper mapper) 
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
        public UserDTO AddUser(UserDTO user)//---
        {
            var userToAdd = _mapper.Map<User>(user);
            if (user != null)
            {
                _repositoryManager.Users.Add(userToAdd);
                _repositoryManager.Save();
            }
            return _mapper.Map<UserDTO>(userToAdd);
        }

        public bool DeleteUser(int id)
        {
            var userDTO = _repositoryManager.Users.GetById(id);
            var userToDelete= _mapper.Map<User>(userDTO);
            if(userToDelete == null) { return false; }
            _repositoryManager.Users.Delete(userToDelete);
            _repositoryManager.Save();
            return true;
        }

        public async Task<IEnumerable<UserDTO>> GetAllUsersAsync()
        {
            var users=await _repositoryManager.Users.GetAllAsync();
            return _mapper.Map<IEnumerable<UserDTO>>(users);
        }

        public UserDTO? GetUserById(int id)
        {
            var user= _repositoryManager.Users.GetById(id);
            return _mapper.Map<UserDTO>(user);
        }

        public UserDTO? UpdateUser(int id, UserDTO user)
        {
            var userToUpdate= _mapper.Map<User>(user);
            if (userToUpdate == null)
            {
                return null;
            }
            _repositoryManager.Users.Update(userToUpdate);
            _repositoryManager.Save();
            return _mapper.Map<UserDTO?>(userToUpdate);
        }

    }
}
