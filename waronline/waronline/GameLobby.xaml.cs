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
    public partial class GameLobby : PhoneApplicationPage
    {
        public static IRoom CurrentRoom { get; set; }

        public GameLobby()
        {
            InitializeComponent();

            foreach (string user in CurrentRoom.UsersInRoom)
            {
                var textBlock = new TextBlock { Text = user };
                PlayerList.Children.Add(textBlock);
            }

            this.Unloaded += GameLobby_Unloaded;
        }

        void GameLobby_Unloaded(object sender, RoutedEventArgs e)
        {
            CurrentRoom = null;
        }
    }
}