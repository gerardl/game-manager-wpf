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
using static GameManager.UI.Views.PlayerList;

namespace GameManager.UI.Views
{
    /// <summary>
    /// Interaction logic for MobView.xaml
    /// </summary>
    public partial class MobView : UserControl
    {
        private MobViewModel _viewModel;

        internal MobViewModel ViewModel
        {
            get { return _viewModel; }
            set
            {
                // null the context so we don't try to
                // bind the player raceid to empty combobox
                DataContext = null;
                _viewModel = value;
                cbRace.Items.Clear();
                foreach (var race in _viewModel.Races)
                {
                    cbRace.Items.Add(new KeyValuePair<int, string>(race.Id, race.Name));
                }
                DataContext = _viewModel.Mob;
            }
        }

        public MobView()
        {
            InitializeComponent();
        }

        private async void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await ViewModel.Save();
            }
            catch (Exception)
            {
                MessageBox.Show("There was an error saving the mob, please try again.");
            }
        }

        private async void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to delete this Mob?",
                    "Delete",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    await ViewModel.Delete();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("There was an error deleting the mob, please try again.");
            }
        }
    }
}
