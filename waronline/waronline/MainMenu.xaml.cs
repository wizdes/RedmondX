namespace waronline
{
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
    using waronline.Data;

    public partial class MainMenu : PhoneApplicationPage
    {
        private ICloudConnector cloudProvider;

        private string playerName;

        private IList<IRoom> roomList;

        public MainMenu()
        {
            InitializeComponent();

            this.cloudProvider = new AzureConnector();
            this.playerName = "Bob";

            this.roomList = this.cloudProvider.ViewRooms(null);

            RoomList.ItemsSource = this.roomList;
        }

        private void JoinRoom(object sender, SelectionChangedEventArgs e)
        {
            IRoom item = (IRoom)e.AddedItems[0];

            this.cloudProvider.JoinRoom(item.RoomName, this.playerName);
        }

        private void CreateRoom_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/CreateRoom.xaml", UriKind.Relative));
        }

        private void EditPlayerName_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/EditPlayerName.xaml", UriKind.Relative));
        }
    }
}