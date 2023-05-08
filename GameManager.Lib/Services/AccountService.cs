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
    public class Account : IAccountService
    {
        private readonly IDataRepository _dataRepository;

        public Account(IDataRepository dataRepository) 
        {
            _dataRepository = dataRepository;
        }

        public async Task<List<AccountType>> GetAccountTypes()
        {
            return await _dataRepository.GetAllAsync<AccountType>();
        }
    }
}
