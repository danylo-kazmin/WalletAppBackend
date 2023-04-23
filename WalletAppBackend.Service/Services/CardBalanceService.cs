using AutoMapper;
using WalletAppBackend.Infrastructure.DataAccess.Contracts;
using WalletAppBackend.Infrastructure.DataAccess.Implementation.Entities;
using WalletAppBackend.Service.Helpers;
using WalletAppBackend.Service.Models;
using WalletAppBackend.Service.Models.Responses;
using WalletAppBackend.Service.Services.Abstractions;

namespace WalletAppBackend.Service.Services
{
    public class CardBalanceService : ICardBalanceService
    {
        private readonly IDbRepository _dbRepository;
        private readonly IMapper _mapper;

        public CardBalanceService(IDbRepository userRepository, IMapper mapper)
            : base()
        {
            _dbRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<GetCardBalanceResponse> GetByIdAsync(Guid id)
        {
            var cardBalance = await _dbRepository.GetByIdAsync<CardBalanceEntity>(id);

            if (cardBalance != null)
            {
                var result = _mapper.Map<CardBalance>(cardBalance);

                return new GetCardBalanceResponse() { CardBalance = result };
            }

            throw new Helpers.KeyNotFoundException("CardBalance didn't found");
        }

        public async Task<CardBalance> AddAsync(Guid userId, decimal amount = 1500)
        {
            var cardBalance = await _dbRepository.GetByUserIdAsync<CardBalanceEntity>(userId);

            if(cardBalance == null)
            {
                var cardBalanceEntity = new CardBalanceEntity()
                {
                    Id = Guid.NewGuid(),
                    Balance = GetRandomNumber(),
                    MaxLimit = amount,
                    UserId = userId
                };

                var newCardBalance = await _dbRepository.AddAsync(cardBalanceEntity);

                if(newCardBalance != null)
                {
                    var result = _mapper.Map<CardBalance>(cardBalance);
                    return result;
                }

                throw new Exception("Server didn't register the cardBalance");
            }

            throw new AppException("CardBalance for this user is already in exist");
        }

        private decimal GetRandomNumber(int max = 1500)
        {
            Random rnd = new Random();
            var randomDecimal = Convert.ToDecimal(rnd.NextDouble() * max);

            return randomDecimal;
        }
    }
}
