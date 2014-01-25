using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using waronline.Data;
namespace waronline
{
    using waronline.Transport;

    public partial class EditPlayerName : PhoneApplicationPage
    {
        public EditPlayerName()
        {
            InitializeComponent();
        }

        private void EditName_Click(object sender, EventArgs e)
        {
            App.cloudConnector.CreateUser(new User
            {
                Username = PlayerName.Text,
                NotificationUrl = App.CurrentChannel.ChannelUri.AbsoluteUri,
                IsActive = true
            });
            NavigationService.Navigate(new Uri("/MainMenu.xaml", UriKind.Relative));
        }
    }
}