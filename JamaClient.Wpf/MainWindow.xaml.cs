using JamaClient.Models;
using JamaClient.Services;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace JamaClient.Wpf
{
    public partial class MainWindow : Window
    {
        private UserService _usersApi = new UserService();

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var parentNode = new TreeViewItem
            {
                Header = "Users"
            };

            Mouse.OverrideCursor = Cursors.Wait;
            DataListResponse<User> response = await _usersApi.GetAsync(includeInactive: true, maxResults: 50);
            Mouse.OverrideCursor = null;

            foreach (User user in response.Data.OrderBy(user => user.Id))
            {
                var childNode = new TreeViewItem
                {
                    Header = $"{user.Id}: {user.FirstName} {user.LastName}"
                };

                parentNode.Items.Add(childNode);
            }

            _treeView.Items.Add(parentNode);
        }
    }
}
