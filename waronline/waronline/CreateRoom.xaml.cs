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
        public CreateRoom()
        {
            InitializeComponent();
        }

        private void CreateRoom_Click(object sender, EventArgs e)
        {
            App.cloudConnector.CreateRoom(NameTextBox.Text, App.playerName).ContinueWith(t => 
                Deployment.Current.Dispatcher.BeginInvoke(() => 
                {
                    IRoom room = t.Result;
                    room.UsersInRoom.Add(App.playerName);
                    GameLobby.CurrentRoom = room;

                    // For now, navigate to view rooms on completion of the call. We need to figure out 
                    // something like a progress bar or some animation while we wait and then launch the game.
                    NavigationService.Navigate(new Uri("/GameLobby.xaml", UriKind.Relative));
                })
            );         
        }
    }
}