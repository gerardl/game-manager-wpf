﻿using GameManager.Lib.Models.Game;
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
        private List<Race> _races = new List<Race>();
        private List<Player> _players = new List<Player>();

        public MainWindow(IGameService gameService)
        {
            InitializeComponent();

            _gameService = gameService;
            ucPlayerList.PlayerSelected += OnPlayerSelected;
            ucPlayer.PlayerSaved += OnPlayer_PlayerSaved;

            Task.Run(async () =>
            {
                _races = await _gameService.GetRacesAsync();
                GetPlayerList();
            });
        }

        private void OnPlayer_PlayerSaved(object? sender, PlayerSelectedEventArgs e)
        {
            Task.Run(() =>
            {
                GetPlayerList();
            });
        }

        async void GetPlayerList()
        {
            _players = await _gameService.GetPlayersAsync();
            this.Dispatcher.Invoke(() => {
                var PlayerListViewModel = new PlayerListViewModel
                {
                    Players = _players
                };
                ucPlayerList.ViewModel = PlayerListViewModel;
            });
        }

        void OnPlayerSelected(object? sender, PlayerSelectedEventArgs e)
        {
            var playerViewModel = new PlayerViewModel
            {
                Player = e.Player,
                Races = _races,
                GameService = _gameService
            };
            ucPlayer.ViewModel = playerViewModel;
        }
    }
}
