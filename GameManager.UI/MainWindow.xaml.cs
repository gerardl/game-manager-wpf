using GameManager.Lib.Models.Game;
using GameManager.Lib.Services;
using GameManager.UI.Models;
using GameManager.UI.ViewModels;
using GameManager.UI.Views;
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
using static GameManager.UI.Views.PlayerList;

namespace GameManager.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IGameService _gameService;
        public MainWindow(IGameService gameService)
        {
            _gameService = gameService;
            InitializeComponent();
        }

        // create event handler for PlayerSelected event
        async void OnPlayerSelected(object? sender, PlayerSelectedEventArgs e)
        {
            var playerViewModel = new PlayerViewModel
            {
                Player = e.Player,
                Races = await _gameService.GetRacesAsync(),
                GameService = _gameService
            };
            ucPlayer.ViewModel = playerViewModel;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var PlayerListViewModel = new PlayerListViewModel
            {
                Players = await _gameService.GetPlayersAsync()
            };
            ucPlayerList.ViewModel = PlayerListViewModel;
            ucPlayerList.PlayerSelected += OnPlayerSelected;

            //var playerViewModel = new PlayerViewModel
            //{
            //    Player = new Player { RaceId = (int)Races.Elf },
            //    Races = await _gameService.GetRacesAsync(),
            //    GameService = _gameService
            //};
            //ucPlayer.ViewModel = playerViewModel;
        }

        private async void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var player = ucPlayer.ViewModel.Player;
            if (player.Id == 0)
            {
                player.Id = await _gameService.AddPlayerAsync(player);
            }
            else
            {
                await _gameService.UpdatePlayerAsync(player);
            }
        }
    }
}
