using AutoMapper;
using WalletAppBackend.Infrastructure.DataAccess.Contracts;
using WalletAppBackend.Infrastructure.DataAccess.Implementation.Entities;
using WalletAppBackend.Service.Models.Responses;
using WalletAppBackend.Service.Models;
using WalletAppBackend.Service.Services.Abstractions;
using WalletAppBackend.Service.Models.Requests;

namespace WalletAppBackend.Service.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly IDbRepository _dbRepository;
        private readonly IMapper _mapper;

        public TransactionService(IDbRepository userRepository, IMapper mapper)
            : base()
        {
            _dbRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<GetTransactionResponse> GetByIdAsync(GetTransactionRequest request)
        {
            var transactionEntity = await _dbRepository.GetByIdAsync<TransactionEntity>(request.Id);

            if (transactionEntity != null)
            {
                var result = _mapper.Map<Transaction>(transactionEntity);

                return new GetTransactionResponse() { Transaction = result };
            }

            throw new Helpers.KeyNotFoundException("Transaction didn't found");
        }

        public async Task<GetAllTransactionsResponse> GetAllByUserIdAsync(GetAllTransactionsByUserIdRequest request)
        {
            var listTransactionEntity = await _dbRepository.GetAllByUserIdAsync<TransactionEntity>(request.UserId);

            if (listTransactionEntity != null)
            {
                var result = new List<Transaction>();

                foreach(var transactionEntity in listTransactionEntity)
                {
                    var transaction = _mapper.Map<Transaction>(transactionEntity);

                    result.Add(transaction);
                }

                return new GetAllTransactionsResponse() { Transactions = result };
            }

            throw new Helpers.KeyNotFoundException("Transactions didn't found");
        }

        public async Task<Transaction> AddAsync(CreateTransactionRequest request)
        {
            var userEntity = await _dbRepository.GetByIdAsync<UserEntity>(request.UserId);
            var senderEntity = await _dbRepository.GetByIdAsync<UserEntity>(request.SenderId);

            if(userEntity != null && senderEntity != null)
            {
                var transactionEntity = new TransactionEntity
                {
                    Id = Guid.NewGuid(),
                    Type = request.Type,
                    Amount = request.Amount,
                    Name = senderEntity.Username,
                    Description = ComputeDescription(request, senderEntity.Username),
                    Date = request.Date,
                    Status = request.Status,
                    IconLink = request.IconLink,
                    SenderId = request.SenderId,
                    UserId = request.UserId,
                    Sender = senderEntity,
                    User = userEntity
                };

                var newTransactionEntity = await _dbRepository.AddAsync(transactionEntity);

                if (newTransactionEntity != null)
                {
                    var result = _mapper.Map<Transaction>(newTransactionEntity);

                    return result;
                }

                throw new Exception("Server didn't register the transaction");
            }

            throw new Helpers.KeyNotFoundException("User or Sender didn't found");

        }

        private string ComputeDescription(CreateTransactionRequest request, string senderName)
        {
            var senderUsername = request.UserId == request.SenderId ? "" : senderName;

            var dateDescription = request.Date >= DateTime.Today.AddDays(-7) ? request.Date.ToString("dddd") : request.Date.ToString("dd.MM.yyyy");

            var statusDescription = request.Status == "Pending" ? "Pending" : "";

            return $"{statusDescription} - {request.Description} ({senderUsername}) {dateDescription}";
        }
    }
}
