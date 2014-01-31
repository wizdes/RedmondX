using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Notification;
using Microsoft.Phone.Shell;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json.Linq;
using waronline.Data;
using waronline.Transport;

namespace waronline
{
    public partial class EditPlayerName : PhoneApplicationPage
    {
        public EditPlayerName()
        {
            InitializeComponent();

            PlayerName.Text = PersistentStorage.Instance.Username ?? string.Empty;
        }

        private async void EditName_Click(object sender, EventArgs e)
        {
            PersistentStorage.Instance.Username = PlayerName.Text;
            User createdUser = await App.cloudConnector.CreateUser(new User
                {
                    Id = PersistentStorage.Instance.UserId,
                    Username = PlayerName.Text,
                    NotificationUrl = App.CurrentChannel.ChannelUri.AbsoluteUri,
                    IsActive = true
                });

            PersistentStorage.Instance.UserId = createdUser.Id;
            NavigationService.Navigate(new Uri("/MainMenu.xaml", UriKind.Relative));
        }

        
    }
}