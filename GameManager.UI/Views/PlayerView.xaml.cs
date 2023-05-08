using GameManager.Lib.Models.Game;
using GameManager.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
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
    /// Interaction logic for PlayerView.xaml
    /// </summary>
    public partial class PlayerView : UserControl
    {
        private PlayerViewModel _viewModel;
        internal PlayerViewModel ViewModel
        {
            get { return _viewModel; }
            set 
            {
                _viewModel = value;
                cbRace.Items.Clear();
                foreach (var race in _viewModel.Races)
                {
                    cbRace.Items.Add(new KeyValuePair<int, string>(race.Id, race.Name));
                }
                DataContext = _viewModel.Player;
            }
        }

        public PlayerView()
        {
            InitializeComponent();
        }

        private async void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var player = ViewModel.Player;
            if (player.Id == 0)
            {
                player.Id = await ViewModel.GameService.AddPlayerAsync(player);
            }
            else
            {
                await ViewModel.GameService.UpdatePlayerAsync(player);
            }
        }
    }
}
