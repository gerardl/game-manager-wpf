using GameManager.Lib.Models.Game;
using GameManager.UI.Models;
using GameManager.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
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

namespace GameManager.UI.Views
{
    /// <summary>
    /// Interaction logic for PlayerList.xaml
    /// </summary>
    public partial class PlayerList : UserControl
    {
        private PlayerListViewModel _viewModel;
        public event EventHandler<PlayerSelectedEventArgs> PlayerSelected;

        internal PlayerListViewModel ViewModel
        {
            get { return _viewModel; }
            set
            {
                _viewModel = value;
                DataContext = _viewModel.Players;
                lvPlayers.ItemsSource = ViewModel.Players;
            }
        }

        public PlayerList()
        {
            InitializeComponent();
        }

        private void lvPlayers_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var player = (Player)lvPlayers.SelectedItem;
            if (player != null)
            {
                PlayerSelected?.Invoke(this, new PlayerSelectedEventArgs { Player = player });
            }
        }

        public class PlayerSelectedEventArgs : EventArgs
        {
            public Player Player { get; set; }
        }
    }
}
