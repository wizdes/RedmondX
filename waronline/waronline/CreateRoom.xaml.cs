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
    using waronline.Data;

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
            this.cloudProvider.CreateRoom(NameTextBox.Text, App.Username).ContinueWith(t => 
                Deployment.Current.Dispatcher.BeginInvoke(() => 
                {
                    // For now, navigate to view rooms on completion of the call. We need to figure out 
                    // something like a progress bar or some animation while we wait and then launch the game.
                    NavigationService.Navigate(new Uri("/MainMenu.xaml", UriKind.Relative));
                })
            );         
        }
    }
}