using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace waronline
{
    using waronline.Transport;

    public partial class CreateRoom : PhoneApplicationPage
    {
        private ICloudConnector cloudProvider;

        public CreateRoom()
        {
            InitializeComponent();

            this.cloudProvider = new AzureConnector();
        }

        private void CreateRoom_Click(object sender, EventArgs e)
        {
            this.cloudProvider.CreateRoom(RoomName.Text);

            // This should launch the game.
            ////NavigationService.Navigate(new Uri("/CreateRoom.xaml", UriKind.Relative));
        }
    }
}