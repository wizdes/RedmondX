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
using System.Collections.ObjectModel;

namespace waronline
{
    public partial class GameLobby : PhoneApplicationPage
    {
        public static IRoom CurrentRoom { get; set; }

        private static ObservableCollection<string> playersInRoom = new ObservableCollection<string>();
        public static ObservableCollection<string> PlayersInRoom
        {
            get
            {
                return playersInRoom;
            }

            set
            {
                playersInRoom = value;
            }
        }

        public GameLobby()
        {
            InitializeComponent();
            this.DataContext = this;
            PlayerList.ItemsSource = PlayersInRoom;

            foreach (string user in CurrentRoom.UsersInRoom)
            {
                PlayersInRoom.Add(user);
            }

            this.Unloaded += GameLobby_Unloaded;
            this.RoomName.Text = CurrentRoom.RoomName;
        }

        void GameLobby_Unloaded(object sender, RoutedEventArgs e)
        {
            CurrentRoom = null;
        }

        private void PlayerList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}