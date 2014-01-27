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
    using Microsoft.WindowsAzure.MobileServices;
    using System.Collections.ObjectModel;
    using System.ComponentModel;

    public partial class MainMenu : PhoneApplicationPage, INotifyPropertyChanged
    {
        private static ObservableCollection<IRoom> roomList = new ObservableCollection<IRoom>();

        public  static ObservableCollection<IRoom> ListOfRooms
        {
            get
            {
                return roomList;
            }
            
            set
            {
                roomList = value;
            }
        }

        public MainMenu()
        {   
            InitializeComponent();
            this.DataContext = this;
            RoomList.ItemsSource = ListOfRooms;
            App.cloudConnector.ViewRooms(null).ContinueWith(t => 
                Deployment.Current.Dispatcher.BeginInvoke(() => {
                try
                {

                    foreach (Room r in t.Result)
                    {
                        ListOfRooms.Add(r);
                    }
                }
                catch (Exception e)
                {
                    Console.Out.WriteLine(e.Message);
                }})
            );

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (string.IsNullOrEmpty(PersistentStorage.Instance.Username))
            {
                NavigationService.Navigate(new Uri("/EditPlayerName.xaml", UriKind.Relative));
            }
        }

        private void JoinRoom(object sender, SelectionChangedEventArgs e)
        {
            IRoom item = (IRoom)e.AddedItems[0];

            App.cloudConnector.JoinRoom(item, PersistentStorage.Instance.Username).ContinueWith(t =>
                Deployment.Current.Dispatcher.BeginInvoke(() => 
                {
                    GameLobby.CurrentRoom = t.Result;
                    NavigationService.Navigate(new Uri("/GameLobby.xaml", UriKind.Relative));
                }));
        }

        private void CreateRoom_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/CreateRoom.xaml", UriKind.Relative));
        }

        private void EditPlayerName_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/EditPlayerName.xaml", UriKind.Relative));
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        // Used to notify the app that a property has changed.
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}