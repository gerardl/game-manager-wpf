using GameManager.Lib.Models.Account;
using GameManager.Lib.Models.Game;
using GameManager.Lib.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GameManager.UI.Models.UserViewModel;
using static GameManager.UI.Views.PlayerList;

namespace GameManager.UI.ViewModels
{
    internal class UserListViewModel
    {
        public List<User> Users { get; set; }
        public IAccountService AccountService { get; set; }
        public event EventHandler<UserSelectedEventArgs> UserSelected;

        public void SelectUser(User user)
        {
            UserSelected?.Invoke(this, new UserSelectedEventArgs { User = user });
        }
    }

    public class UserSelectedEventArgs : EventArgs
    {
        public User User { get; set; }
    }
}
