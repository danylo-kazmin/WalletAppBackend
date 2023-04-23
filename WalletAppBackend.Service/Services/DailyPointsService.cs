using AutoMapper;
using WalletAppBackend.Infrastructure.DataAccess.Contracts;
using WalletAppBackend.Infrastructure.DataAccess.Implementation.Entities;
using WalletAppBackend.Service.Models.Responses;
using WalletAppBackend.Service.Models;
using WalletAppBackend.Service.Services.Abstractions;

namespace WalletAppBackend.Service.Services
{
    public class DailyPointsService : IDailyPointsService
    {
        private readonly IDbRepository _dbRepository;
        private readonly IMapper _mapper;

        public DailyPointsService(IDbRepository dbRepository, IMapper mapper)
            : base()
        {
            _dbRepository = dbRepository;
            _mapper = mapper;
        }

        public async Task<GetDailyPointsResponse> GetByDayAsync(int dayOfSeasone)
        {
            var dailyPoints = await _dbRepository.GetByDayAsync<DailyPointsEntity>(dayOfSeasone);

            dailyPoints.Points = RoundPoints(dailyPoints.Points);

            if (dailyPoints != null)
            {
                var result = _mapper.Map<DailyPoints>(dailyPoints);

                return new GetDailyPointsResponse() { DailyPoints = result };
            }

            throw new Helpers.KeyNotFoundException("DailyPoints didn't found");
        }

        public async Task<List<DailyPoints>> AddAsync(Guid userId, int daysInSeason = 92)
        {
            var listOfDailyPoints = CreateDailyPointsForSeason(daysInSeason);
            var entities = new List<DailyPointsEntity>();
            var dayOfSeasone = 0;

            foreach (var dailyPoints in listOfDailyPoints)
            {
                entities.Add(new DailyPointsEntity()
                {
                    Id = Guid.NewGuid(),
                    Points = dailyPoints,
                    DayOfSeasone = dayOfSeasone + 1,
                    UserId = userId,
                });
            }

            var newDailyPoints = await _dbRepository.AddRangeAsync(entities);

            if(newDailyPoints != null)
            {
                var result = new List<DailyPoints>();

                foreach(var dailyPoints in newDailyPoints)
                {
                    var model = _mapper.Map<DailyPoints>(dailyPoints);

                    result.Add(model);
                }

                return result;
            }

            throw new Exception("Server didn't add the new DailyPoints");
        }

        private List<long> CreateDailyPointsForSeason(int daysInSeason)
        {
            var previousPoints = new List<long>();

            for (var dayOfSeason = 0; dayOfSeason <= daysInSeason; dayOfSeason++)
            {
                long dailyPoints;

                if (dayOfSeason == 0)
                {
                    dailyPoints = 2;
                }
                else if (dayOfSeason == 1)
                {
                    dailyPoints = 3;
                }
                else
                {
                    var previousDayPoints = previousPoints[dayOfSeason - 1];
                    var dayBeforePreviousDayPoints = previousPoints[dayOfSeason - 2];
                    var totalPoints = previousDayPoints + dayBeforePreviousDayPoints * 0.6;

                    dailyPoints = (long)totalPoints;
                }

                previousPoints.Add(dailyPoints);
            }

            return previousPoints;
        }

        private long RoundPoints(long points)
        {
            var roundedPoints = (long)Math.Round((decimal)points);

            return points >= 1000 ? (roundedPoints / 1000 * 1000) : roundedPoints;
        }
    }
}
