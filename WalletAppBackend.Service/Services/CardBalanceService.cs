using AutoMapper;
using WalletAppBackend.Infrastructure.DataAccess.Contracts;
using WalletAppBackend.Infrastructure.DataAccess.Implementation.Entities;
using WalletAppBackend.Service.Helpers;
using WalletAppBackend.Service.Models;
using WalletAppBackend.Service.Models.Requests;
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

        public async Task<GetCardBalanceResponse> GetByIdAsync(GetCardBalanceRequest request)
        {
            var cardBalance = await _dbRepository.GetByIdAsync<CardBalanceEntity>(request.Id);

            if (cardBalance != null)
            {
                var result = _mapper.Map<CardBalance>(cardBalance);

                return new GetCardBalanceResponse() { CardBalance = result };
            }

            throw new Helpers.KeyNotFoundException("CardBalance didn't found");
        }

        public async Task<CardBalance> AddAsync(Guid userId, int maxLimit = 1500)
        {
            var listCardBalance = await _dbRepository.GetAllByUserIdAsync<CardBalanceEntity>(userId);
            var cardBalance = listCardBalance.FirstOrDefault();

            if (cardBalance == null)
            {
                var cardBalanceEntity = new CardBalanceEntity()
                {
                    Id = Guid.NewGuid(),
                    Balance = GetRandomNumber(maxLimit),
                    MaxLimit = maxLimit,
                    UserId = userId,
                    PaymentMessage = GetPaymentMessage()
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

        private decimal GetRandomNumber(int maxNumber)
        {
            Random rnd = new Random();
            var randomDecimal = Convert.ToDecimal(rnd.NextDouble() * maxNumber);

            return randomDecimal;
        }

        private string GetPaymentMessage()
        {
            return $"You've paid your {DateTime.Now.ToString("MMMM")} balance.";
        }
    }
}
