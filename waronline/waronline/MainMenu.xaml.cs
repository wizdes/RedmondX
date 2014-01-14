using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

using waronline.Transport;
using waronline.Game;

namespace waronline
{
    public partial class MainMenu : PhoneApplicationPage
    {
        private ICloud cloudProvider;

        private string playerName;

        private IList<IRoom> roomList;

        public MainMenu()
        {
            InitializeComponent();

            cloudProvider = new AzureConnector();
            playerName = "Bob";

            roomList = cloudProvider.ViewRooms(null);

            RoomList.ItemsSource = roomList;
        }

        private void SetPlayerName_Click(object sender, RoutedEventArgs e)
        {
            this.playerName = PlayerName.Text;
            cloudProvider.CreateUser(playerName);
        }

        private void JoinRoom(object sender, SelectionChangedEventArgs e)
        {
            IRoom item = (IRoom)e.AddedItems[0];

            cloudProvider.JoinRoom(item.RoomName, this.playerName);
        }

        private void CreateRoom_Click(object sender, RoutedEventArgs e)
        {
            cloudProvider.CreateRoom(RoomName.Text);
        }
    }
}