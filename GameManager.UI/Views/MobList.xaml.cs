using GameManager.Lib.Models.Game;
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
    /// Interaction logic for MobList.xaml
    /// </summary>
    public partial class MobList : UserControl
    {
        private MobListViewModel _viewModel;

        internal MobListViewModel ViewModel
        {
            get { return _viewModel; }
            set
            {
                _viewModel = value;
                DataContext = _viewModel.Mobs;
                lvMobs.ItemsSource = ViewModel.Mobs;
            }
        }

        public MobList()
        {
            InitializeComponent();
        }

        private void lvMobs_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var mob = (Mob)lvMobs.SelectedItem;
            if (mob != null)
            {
                _viewModel.SelectMob(mob);
            }
        }

        private void btnAddMob_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.SelectMob(new Mob());
        }
    }
}
