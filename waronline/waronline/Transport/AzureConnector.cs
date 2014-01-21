namespace waronline.Transport
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.WindowsAzure.MobileServices;
    using waronline.Data;
    using Newtonsoft.Json.Linq;

    public class AzureConnector : ICloudConnector
    {
        // <summary>
        /// Creates a user in the cloud.
        /// </summary>
        /// <param name="username">The username of the user being created.</param>
        public async void CreateUser(string username)
        {
            var item = new JObject();
            item["username"] = App.Username;
            item["is_active"] = true;
            item["notification_url"] = App.CurrentChannel.ChannelUri.AbsoluteUri;
            try
            {
                var result = await App.MobileService.InvokeApiAsync("users", item);
            }
            catch (Exception e)
            {
                Console.Out.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Creates a room in the cloud.
        /// </summary>
        /// <param name="roomName">The name of the room being created.</param>
        /// <param name="createdBy">The username of the user creating the room.</param>
        /// <returns>The created <see cref="IRoom"/>.</returns>
        public async Task CreateRoom(string roomName, string createdBy)
        {
            var item = new JObject();
            item["createdBy"] = createdBy;
            item["roomName"] = roomName;
            var result = await App.MobileService.InvokeApiAsync("rooms", item, HttpMethod.Post, null);
        }

        /// <summary>
        /// Join an existing room.
        /// </summary>
        /// <param name="roomName">The name of the room to join.</param>
        /// <param name="username">The username of the user joining the specified room.</param>
        public async Task<IRoom> JoinRoom(string roomName, string username)
        {
            var item = new JObject();
            item["roomName"] = roomName;
            item["username"] = username;
            var result = await App.MobileService.InvokeApiAsync("usersinrooms", item, HttpMethod.Post, null);
            IRoom room = new Room();
            string[] users = result["users"].Value<string>().Split(new char[]{','}, StringSplitOptions.RemoveEmptyEntries);
            room.UsersInRoom = new List<string>(users);
            room.RoomId = result["roomId"].Value<string>();
            room.RoomName = result["roomName"].Value<string>();

            return room;
        }

        /// <summary>
        /// View the list of existing rooms.
        /// </summary>
        /// <param name="friendNames">
        /// A list of names of the friends of the current user.
        /// If not null, only the rooms created by these users are returned.
        /// </param>
        /// <returns>A List of rooms currently active.</returns>
        public async Task<IList<IRoom>> ViewRooms(IList<string> friendNames)
        {
            var item = new Dictionary<string, string>();
            if (friendNames != null)
            {
                item.Add("friends", string.Join(",", friendNames));
            }

            var results = await App.MobileService.InvokeApiAsync("rooms", null, HttpMethod.Get, item);

            var rooms = new List<IRoom>();
            foreach (var result in results)
            {
                 rooms.Add(result.ToObject<Room>());
            }

            return rooms;
        }

        /// <summary>
        /// Sends a message to other users in the room.
        /// </summary>
        /// <param name="message">The <see cref="IMessage"/> being sent.</param>
        public async void SendMessage(IMessage message)
        {
            var item = message as JObject;
            var result = await App.MobileService.InvokeApiAsync("messages", item, HttpMethod.Post, null);
        }
    }
}
