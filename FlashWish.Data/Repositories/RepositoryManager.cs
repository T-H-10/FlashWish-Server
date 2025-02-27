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
        private readonly Core.Repositories.IRepository<User> _userRepository;
        private readonly Core.Repositories.IRepository<Template> _templateRepository;
        private readonly Core.Repositories.IRepository<GreetingCard> _greetingCardRepository;
        private readonly Core.Repositories.IRepository<GreetingMessage> _greetingMessageRepository;
        private readonly Core.Repositories.IRepository<Category> _categoryRepository;
        public RepositoryManager(DataContext context,
                                Core.Repositories.IRepository<User> userRepository,
                                Core.Repositories.IRepository<Template> templateRepository,
                                Core.Repositories.IRepository<GreetingCard> greetingCardRepository,
                                Core.Repositories.IRepository<GreetingMessage> greetingMessageRepository,
                                Core.Repositories.IRepository<Category> categoryRepository) 
        {
            _context = context;
            _userRepository = userRepository;
            _templateRepository = templateRepository;
            _greetingCardRepository = greetingCardRepository;
            _greetingMessageRepository = greetingMessageRepository;
            _categoryRepository = categoryRepository;
        }

        public Core.Repositories.IRepository<User> Users => _userRepository;
        public Core.Repositories.IRepository<Template> Templates => _templateRepository;
        public Core.Repositories.IRepository<GreetingMessage> GreetingMessages => _greetingMessageRepository;
        public Core.Repositories.IRepository<GreetingCard> GreetingCards => _greetingCardRepository;
        public Core.Repositories.IRepository<Category> Categories => _categoryRepository;

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
