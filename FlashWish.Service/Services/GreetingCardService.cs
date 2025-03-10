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
    public class GreetingCardService : IGreetingCardService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public GreetingCardService(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
        public GreetingCardDTO AddGreetingCard(GreetingCardDTO greetingCard)//---
        {
            var greetingCardToAdd = _mapper.Map<GreetingCard>(greetingCard);
            if (greetingCardToAdd != null)
            {
                _repositoryManager.GreetingCards.Add(greetingCardToAdd);
                _repositoryManager.Save();
            }
            return _mapper.Map<GreetingCardDTO>(greetingCardToAdd);
        }

        public bool DeleteGreetingCard(int id)
        {
            var greetingCardDTO = _repositoryManager.GreetingCards.GetByIdAsync(id);
            var greetingCardToDelete = _mapper.Map<GreetingCard>(greetingCardDTO);
            if (greetingCardToDelete == null) { return false; }
            _repositoryManager.GreetingCards.Delete(greetingCardToDelete);
            _repositoryManager.Save();
            return true;
        }


        public async Task<IEnumerable<GreetingCardDTO>> GetAllGreetingCardsAsync()
        {
            var greetingCards = await _repositoryManager.GreetingCards.GetAllAsync();
            return _mapper.Map<IEnumerable<GreetingCardDTO>>(greetingCards);
        }


        public GreetingCardDTO? GetGreetingCardById(int id)
        {
            var greetingCard = _repositoryManager.GreetingCards.GetByIdAsync(id);
            return _mapper.Map<GreetingCardDTO>(greetingCard);
        }


        public GreetingCardDTO? UpdateGreetingCard(int id, GreetingCardDTO greetingCard)
        {
            if (greetingCard == null) return null;
            var greetingCardToUpdate = _mapper.Map<GreetingCard>(greetingCard);
            _repositoryManager.GreetingCards.Update(id, greetingCardToUpdate);
            _repositoryManager.Save();
            return _mapper.Map<GreetingCardDTO?>(greetingCardToUpdate);
        }
    }
}
