using GameManager.Lib.Models.Inventory;
using GameManager.UI.Models;
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
using System.Windows.Shapes;

namespace GameManager.UI
{
    /// <summary>
    /// Interaction logic for InventoryWindow.xaml
    /// </summary>
    public partial class InventoryWindow : Window
    {
        private PlayerViewModel _playerViewModel;
        public InventoryWindow(PlayerViewModel playerViewModel)
        {
            InitializeComponent();
            _playerViewModel = playerViewModel;
            dgInventory.ItemsSource = _playerViewModel.Inventory;
        }

        async void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await _playerViewModel.SaveInventory();
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to save inventory; please try again.");
            }
        }
    }
}
