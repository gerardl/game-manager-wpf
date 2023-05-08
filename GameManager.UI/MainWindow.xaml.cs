using GameManager.Lib.Models.Game;
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
using static GameManager.UI.Views.PlayerList;

namespace GameManager.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IGameService _gameService;
        private List<Player> _players = new List<Player>();
        List<UserControl> _userControls = new List<UserControl>();

        public MainWindow(IGameService gameService)
        {
            InitializeComponent();

            _gameService = gameService;
        }

        private void OnPlayerSaved(object? sender, PlayerSavedEventArgs e)
        {
            Task.Run(() =>
            {
               // GetPlayerList();
            });
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
            MainContent.Children.Add(ucPlayer);
        }

        async void btnPlayers_Click(object sender, RoutedEventArgs e)
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

        async void btnMobs_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Children.Clear();
            var ucMobList = new MobList();
            var mobs = await _gameService.GetMobsAsync();

            ucMobList.ViewModel = new MobListViewModel();
            ucMobList.ViewModel.MobSelected += OnMobSelected;
            MainContent.Children.Add(ucMobList);
        }

        async void OnMobSelected(object? sender, MobSelectedEventArgs e)
        {
            MainContent.Children.Clear();

            // get fresh data
            var races = await _gameService.GetRacesAsync();
            var mob = await _gameService.GetMobAsync(e.Mob.Id);
            var ucMob = new MobView();

            ucMob.ViewModel = new MobViewModel(_gameService, mob, races);
            //ucMob.ViewModel.MobSaved += OnPlayerSaved;
            MainContent.Children.Add(ucMob);
        }
    }
}
