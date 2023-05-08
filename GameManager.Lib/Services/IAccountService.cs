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
    public interface IAccountService
    {
        Task<List<User>> GetAccountsAsync();
        Task<User> GetUserAsync(int id);
        Task<int> AddUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(User user);
        Task<List<AccountType>> GetAccountTypes();
    }
}
