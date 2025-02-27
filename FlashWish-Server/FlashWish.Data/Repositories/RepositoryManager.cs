using FlashWish.Core.Entities;
using FlashWish.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashWish.Data.Repositories
{
    public class RepositoryManager: IRepositoryManager
    {
        private readonly DataContext _context;
        private readonly IRepository<User> _userRepository;
        public RepositoryManager(DataContext context, IRepository<User> userRepository) 
        {
            _context = context;
            _userRepository = userRepository;
        }

        public IRepository<User> Users => _userRepository;

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
