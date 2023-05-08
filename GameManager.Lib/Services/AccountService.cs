using GameManager.Lib.Models.Account;
using GameManager.Lib.Models.Game;
using GameManager.Lib.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameManager.Lib.Services
{
    public class AccountService : IAccountService
    {
        private readonly IDataRepository _dataRepository;

        public AccountService(IDataRepository dataRepository) 
        {
            _dataRepository = dataRepository;
        }

        public async Task<List<User>> GetAccountsAsync()
        {
            return await _dataRepository.GetAllAsync<User>();
        }

        public async Task<User> GetUserAsync(int id)
        {
            return await _dataRepository.GetEntityAsync<User>(id);
        }

        public async Task<int> AddUserAsync(User user)
        {
            return (await _dataRepository.AddEntityAsync(user)).Id;
        }

        public async Task UpdateUserAsync(User user)
        {
            await _dataRepository.UpdateEntityAsync(user);
        }

        public async Task DeleteUserAsync(User user)
        {
            await _dataRepository.DeleteEntityAsync(user);
        }

        public async Task<List<AccountType>> GetAccountTypes()
        {
            return await _dataRepository.GetAllAsync<AccountType>();
        }
    }
}
