using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalletAppBackend.Infrastructure.DataAccess.Contracts;
using WalletAppBackend.Infrastructure.DataAccess.Implementation.Entities;
using WalletAppBackend.Service.Models;
using WalletAppBackend.Service.Services.Abstractions;

namespace WalletAppBackend.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IDbRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IDbRepository userRepository, IMapper mapper)
            : base()
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<GetAllResponse> GetAll()
        {
            var entities = await _userRepository.GetAll<UserEntity>();

            if (entities != null)
            {
                var result = new List<User>();

                foreach (var user in entities)
                {
                    var model = _mapper.Map<User>(user);
                    result.Add(model);
                }

                return new GetAllResponse() { Users = result };
            }

            throw new Helpers.KeyNotFoundException();
        }

        public async Task<User> GetById(Guid id)
        {
            var user = await _userRepository.Get<UserEntity>(id);

            if (user != null)
            {
                var result = _mapper.Map<User>(user);

                return new GetByIdResponse() { User = result };
            }

            throw new Helpers.KeyNotFoundException("User didn't found");
        }

        public async Task<User> RegisterAsync(string username, string email, string password)
        {
            //check username

            if (userDb == null)
            {
                var user = new UserEntity()
                {
                    Id = Guid.NewGuid(),
                    Username = username,
                    Email = email,
                    PasswordHash = _wrapper.GetHashString(password),
                    IsActive = true,
                    Role = Role.User
                };

                var result = await _userRepository.AddAsync(user);

                if (result != null)
                {
                    var response = await Authenticate(username, password);
                    return response;
                }

                throw new Exception("Server didn't register the user");
            }

            throw new AppException("Username or email is already in user");
        }

        public async Task<BlockResponse> UpdateBlockAsync(Guid id)
        {
            var user = await _userRepository.Get<UserEntity>(id);

            if (user != null)
            {
                user.IsActive = !user.IsActive;
                var success = await _userRepository.BlockAsync(user);

                return new BlockResponse() { Success = success };
            }

            throw new Helpers.KeyNotFoundException("User didn't found");
        }

        public async Task<UpdateEmailResponse> UpdateEmailAsync(Guid id, string newEmail, string password)
        {
            var user = await _userRepository.Get<UserEntity>(id);

            if (user != null)
            {
                var hashPassword = _wrapper.GetHashString(password);

                if (hashPassword == user.PasswordHash)
                {
                    user.Email = newEmail;
                    var updated = await _userRepository.UpdateAsync(user);

                    if (updated)
                    {
                        var result = _mapper.Map<User>(user);

                        return new UpdateEmailResponse() { User = result };
                    }

                    throw new Exception("Email has not been updated");
                }

                throw new AppException("Wrong password");
            }

            throw new Helpers.KeyNotFoundException("User didn't found");
        }

        public async Task<UpdatePasswordResponse> UpdatePasswordAsync(Guid id, string newPassword, string oldPassword)
        {
            var user = await _userRepository.Get<UserEntity>(id);

            if (user != null)
            {
                var hashOldPassword = _wrapper.GetHashString(oldPassword);

                if (hashOldPassword == user.PasswordHash)
                {

                    user.PasswordHash = _wrapper.GetHashString(newPassword);
                    var updated = await _userRepository.UpdateAsync(user);

                    if (updated)
                    {
                        var result = _mapper.Map<User>(user);

                        return new UpdatePasswordResponse() { User = result };
                    }

                    throw new Exception("Password has not been updated");
                }

                throw new AppException("Wrong password");
            }

            throw new Helpers.KeyNotFoundException("User didn't found");
        }

        public async Task<RemoveResponse> RemoveUserAsync(Guid id)
        {
            var success = await _userRepository.RemoveAsync<UserEntity>(id);

            if (success)
            {
                return new RemoveResponse() { IsRemoved = success };
            }

            throw new Helpers.KeyNotFoundException("User didn't found");
        }
    }
}
