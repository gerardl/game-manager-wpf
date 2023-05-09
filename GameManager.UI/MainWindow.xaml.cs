using GameManager.Lib.Models.Game;
using GameManager.Lib.Models.Inventory;
using GameManager.Lib.Services;
using GameManager.UI.Models;
using GameManager.UI.ViewModels;
using GameManager.UI.Views;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static GameManager.UI.Models.PlayerViewModel;
using static GameManager.UI.Models.UserViewModel;
using static GameManager.UI.Views.PlayerList;

namespace GameManager.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IGameService _gameService;
        private readonly IAccountService _accountService;

        private List<Player> _players = new List<Player>();
        List<UserControl> _userControls = new List<UserControl>();

        public MainWindow(IGameService gameService, IAccountService accountService)
        {
            InitializeComponent();

            _gameService = gameService;
            _accountService = accountService;
        }

        #region Players

        async void btnPlayers_Click(object sender, RoutedEventArgs e)
        {
            await ShowPlayerList();
        }

        async void OnPlayerSaved(object? sender, PlayerSavedEventArgs e)
        {
            await ShowPlayerList();
        }

        async void OnPlayerDeleted(object? sender, PlayerDeletedEventArgs e)
        {
            await ShowPlayerList();
        }

        private async Task ShowPlayerList()
        {
            MainContent.Children.Clear();
            var pList = new PlayerList();
            _players = await _gameService.GetPlayersAsync();
            var PlayerListViewModel = new PlayerListViewModel
            {
                Players = _players
            };
            pList.ViewModel = PlayerListViewModel;
            pList.ViewModel.PlayerSelected += OnPlayerSelected;
            MainContent.Children.Add(pList);
        }

        async void OnPlayerSelected(object? sender, PlayerSelectedEventArgs e)
        {
            MainContent.Children.Clear();

            // get fresh data
            var races = await _gameService.GetRacesAsync();
            var player = e.Player.Id > 0 ? await _gameService.GetPlayerAsync(e.Player.Id) : e.Player;
            var ucPlayer = new PlayerView();

            ucPlayer.ViewModel = new PlayerViewModel(_gameService, player, races);
            ucPlayer.ViewModel.PlayerSaved += OnPlayerSaved;
            ucPlayer.ViewModel.PlayerDeleted += OnPlayerDeleted;
            MainContent.Children.Add(ucPlayer);
        }

        #endregion

        #region Mobs

        async void btnMobs_Click(object sender, RoutedEventArgs e)
        {
           await ShowMobList();
        }

        async void OnMobSaved(object? sender, MobSavedEventArgs e)
        {
            await ShowMobList();
        }

        async void OnMobDeleted(object? sender, MobDeletedEventArgs e)
        {
            await ShowMobList();
        }

        async void OnMobSelected(object? sender, MobSelectedEventArgs e)
        {
            MainContent.Children.Clear();

            // get fresh data
            var races = await _gameService.GetRacesAsync();
            var mob = e.Mob.Id > 0 ? await _gameService.GetMobAsync(e.Mob.Id) : e.Mob;
            var ucMob = new MobView();

            ucMob.ViewModel = new MobViewModel(_gameService, mob, races);
            ucMob.ViewModel.MobSaved += OnMobSaved;
            ucMob.ViewModel.MobDeleted += OnMobDeleted;
            MainContent.Children.Add(ucMob);
        }

        private async Task ShowMobList()
        {
            MainContent.Children.Clear();
            var ucMobList = new MobList();
            var mobs = await _gameService.GetMobsAsync();

            ucMobList.ViewModel = new MobListViewModel
            {
                Mobs = mobs
            };
            ucMobList.ViewModel.MobSelected += OnMobSelected;
            MainContent.Children.Add(ucMobList);
        }

        #endregion

        #region Users

        private async void btnAccounts_Click(object sender, RoutedEventArgs e)
        {
            await ShowUserList();
        }

        async void OnUserSelected(object? sender, UserSelectedEventArgs e)
        {
            MainContent.Children.Clear();

            // get fresh data
            var accountTypes = await _accountService.GetAccountTypes();
            var user = e.User.Id > 0 ? await _accountService.GetUserAsync(e.User.Id) : e.User;
            var ucUser = new UserView();

            ucUser.ViewModel = new UserViewModel(_accountService, user, accountTypes);
            ucUser.ViewModel.UserSaved += OnUserSaved;
            ucUser.ViewModel.UserDeleted += OnUserDeleted;
            MainContent.Children.Add(ucUser);
        }

        async void OnUserSaved(object? sender, UserSavedEventArgs e)
        {
            await ShowUserList();
        }

        async void OnUserDeleted(object? sender, UserDeletedEventArgs e)
        {
            await ShowUserList();
        }

        private async Task ShowUserList()
        {
            MainContent.Children.Clear();
            var ucUserList = new UserList();
            var users = await _accountService.GetAccountsAsync();

            ucUserList.ViewModel = new UserListViewModel
            {
                Users = users
            };
            ucUserList.ViewModel.UserSelected += OnUserSelected;
            MainContent.Children.Add(ucUserList);
        }

        #endregion

    }
}
