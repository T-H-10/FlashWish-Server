using FlashWish.Core.DTOs;
using FlashWish.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashWish.Core.IServices
{
    public interface IGreetingCardService
    {
        Task<IEnumerable<GreetingCardDTO>> GetAllGreetingCardsAsync();
        GreetingCardDTO? GetGreetingCardById(int id);
        GreetingCardDTO AddGreetingCard(GreetingCardDTO user);
        GreetingCardDTO? UpdateGreetingCard(int id, GreetingCardDTO user);
        bool DeleteGreetingCard(int id);
    }
}
