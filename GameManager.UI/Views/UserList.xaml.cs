using GameManager.Lib.Models.Game;
using GameManager.Lib.Models.Account;
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
    /// Interaction logic for UserList.xaml
    /// </summary>
    public partial class UserList : UserControl
    {
        private UserListViewModel _viewModel;

        internal UserListViewModel ViewModel
        {
            get { return _viewModel; }
            set
            {
                _viewModel = value;
                lvUsers.ItemsSource = null;
                lvUsers.ItemsSource = _viewModel.Users;
            }
        }

        public UserList()
        {
            InitializeComponent();
        }

        private void lvUsers_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            var user = (User)lvUsers.SelectedItem;
            if (user != null)
            {
                _viewModel.SelectUser(user);
            }
        }

        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.SelectUser(new User());
        }
    }
}
