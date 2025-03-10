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
    public class GreetingMessageService : IGreetingMessageService
    {
        public readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public GreetingMessageService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
        public GreetingMessageDTO AddGreetingMessage(GreetingMessageDTO message)
        {
            var messageToAdd = _mapper.Map<GreetingMessage>(message);
            if (message != null)
            {
                _repositoryManager.GreetingMessages.Add(messageToAdd);
                _repositoryManager.Save();
            }
            return _mapper.Map<GreetingMessageDTO>(messageToAdd);
        }

        public bool DeleteGreetingMessage(int id)
        {
            var messageDTO = _repositoryManager.GreetingMessages.GetByIdAsync(id);
            var messageToDelete = _mapper.Map<GreetingMessage>(messageDTO);
            if (messageToDelete == null) { return false; }
            _repositoryManager.GreetingMessages.Delete(messageToDelete);
            _repositoryManager.Save();
            return true;
        }

        public async Task<IEnumerable<GreetingMessageDTO>> GetAllMessagesAsync()
        {
            var messages = await _repositoryManager.GreetingMessages.GetAllAsync();
            return _mapper.Map<IEnumerable<GreetingMessageDTO>>(messages);

        }

        public GreetingMessageDTO? GetGreetingMessageById(int id)
        {
            var message = _repositoryManager.GreetingMessages.GetByIdAsync(id);
            return _mapper.Map<GreetingMessageDTO>(message);

        }

        public GreetingMessageDTO? UpdateGreetingMessage(int id, GreetingMessageDTO message)
        {
            if (message == null) return null;
            var messageToUpdate = _mapper.Map<GreetingMessage>(message);
            _repositoryManager.GreetingMessages.Update(id, messageToUpdate);
            _repositoryManager.Save();
            return _mapper.Map<GreetingMessageDTO?>(messageToUpdate);
        }
    }
}
