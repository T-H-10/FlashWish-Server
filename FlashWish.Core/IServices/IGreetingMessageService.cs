using FlashWish.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashWish.Core.IServices
{
    public interface IGreetingMessageService
    {
        Task<IEnumerable<GreetingMessageDTO>> GetAllMessagesAsync();
        GreetingMessageDTO? GetGreetingMessageById(int id);
        GreetingMessageDTO AddGreetingMessage(GreetingMessageDTO message);
        GreetingMessageDTO? UpdateGreetingMessage(int id, GreetingMessageDTO message);
        bool DeleteGreetingMessage(int id);
    }
}
