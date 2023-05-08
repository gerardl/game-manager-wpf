using GameManager.Lib.Models.Account;
using GameManager.Lib.Models.Game;
using GameManager.Lib.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GameManager.UI.Models
{
    internal class UserViewModel
    {
        private readonly IAccountService _accountService;
        public User User { get; set; }
        public List<AccountType> AccountTypes { get; set; }
        public event EventHandler<UserSavedEventArgs> UserSaved;
        public event EventHandler<UserDeletedEventArgs> UserDeleted;

        public UserViewModel(IAccountService accountService, User user, List<AccountType> accountTypes) 
        {
            _accountService = accountService;
            User = user;
            AccountTypes = accountTypes;
        }

        public async Task Save()
        {
            try
            {
                if (User.Id == 0)
                {
                    User.PasswordHash = "NA";
                    User.Id = await _accountService.AddUserAsync(User);
                }
                else
                {
                    await _accountService.UpdateUserAsync(User);
                }
                UserSaved?.Invoke(this, new UserSavedEventArgs { User = User });
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task Delete()
        {
            try
            {
                if (User.Id != 0)
                {
                    await _accountService.DeleteUserAsync(User);
                }
                UserDeleted?.Invoke(this, new UserDeletedEventArgs { User = User });
                User = new User();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public class UserSavedEventArgs : EventArgs
        {
            public User User { get; set; }
        }

        public class UserDeletedEventArgs : EventArgs
        {
            public User User { get; set; }
        }
    }
}
