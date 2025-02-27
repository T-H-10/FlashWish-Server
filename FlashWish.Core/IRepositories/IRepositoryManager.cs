using FlashWish.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashWish.Core.Repositories
{
    public interface IRepositoryManager
    {
        IRepository<User> Users { get; }
        IRepository<Template> Templates { get; }
        IRepository<GreetingMessage> GreetingMessages { get; }
        IRepository<GreetingCard> GreetingCards { get; }
        IRepository<Category> Categories { get; }
        void Save();
    }
}
