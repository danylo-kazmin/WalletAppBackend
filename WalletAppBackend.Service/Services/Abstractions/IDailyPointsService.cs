using WalletAppBackend.Service.Models;
using WalletAppBackend.Service.Models.Responses;

namespace WalletAppBackend.Service.Services.Abstractions
{
    public interface IDailyPointsService
    {
        Task<GetDailyPointsResponse> GetByDayAsync(int dayOfSeasone);
        Task<List<DailyPoints>> AddAsync(Guid userId, int daysInSeason = 92);
    }
}
