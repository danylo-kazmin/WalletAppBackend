using AutoMapper;
using Microsoft.Extensions.Configuration;
using WalletAppBackend.Infrastructure.DataAccess.Contracts;
using WalletAppBackend.Infrastructure.DataAccess.Implementation.Entities;
using WalletAppBackend.Service.Helpers;
using WalletAppBackend.Service.Models;
using WalletAppBackend.Service.Models.Responses;
using WalletAppBackend.Service.Services.Abstractions;

namespace WalletAppBackend.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IDbRepository _dbRepository;
        private readonly IMapper _mapper;
        private readonly ICardBalanceService _cardBalanceService;
        private readonly IDailyPointsService _dailyPointsService;

        public UserService(IDbRepository userRepository, IMapper mapper, ICardBalanceService cardBalanceService, IDailyPointsService dailyPointsService)
            : base()
        {
            _dbRepository = userRepository;
            _mapper = mapper;
            _cardBalanceService = cardBalanceService;
            _dailyPointsService = dailyPointsService;
        }

        public async Task<GetAllUsersResponse> GetAllAsync()
        {
            var entities = await _dbRepository.GetAllAsync<UserEntity>();

            if (entities != null)
            {
                var result = new List<User>();

                foreach (var user in entities)
                {
                    var model = _mapper.Map<User>(user);
                    result.Add(model);
                }

                return new GetAllUsersResponse() { Users = result };
            }

            throw new Helpers.KeyNotFoundException();
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            var user = await _dbRepository.GetByIdAsync<UserEntity>(id);

            if (user != null)
            {
                var result = _mapper.Map<User>(user);

                return result;
            }

            throw new Helpers.KeyNotFoundException("User didn't found");
        }

        public async Task<CreateUserResponses> AddAsync(string username)
        {
            var user = _dbRepository.GetByUsernameAsync<UserEntity>(username);

            if (user == null)
            {
                var userId = Guid.NewGuid();
                var cardBalance = await _cardBalanceService.AddAsync(userId);

                var cardBalanceEntity = new CardBalanceEntity()
                {
                    Id = cardBalance.Id,
                    Balance = cardBalance.Balance,
                    MaxLimit = cardBalance.MaxLimit,
                    UserId = userId,
                };

                var userEntity = new UserEntity()
                {
                    Id = userId,
                    Username = username,
                    IconLink = "https://drive.google.com/file/d/1jd6nssk0Vg9Y0_DZA4i1LBSiFvf-tXvz/view?usp=sharing", //Temporary solution
                    CardBalance = cardBalanceEntity,
                    Transactions = new List<TransactionEntity>()
                };

                var newUser = await _dbRepository.AddAsync(userEntity);

                if (userEntity != null)
                {
                    var result = _mapper.Map<User>(newUser);
                    result.DailyPoints = _dailyPointsService.GetByDayAsync().Result.DailyPoints.Points.ToString();

                    return new CreateUserResponses() { User = result };
                }

                throw new Exception("Server didn't register the user");
            }

            throw new AppException("Username or email is already in user");
        }

    }
}
