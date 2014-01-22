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
        public async Task<User> CreateUser(User user)
        {
            var item = new JObject();
            item["version"] = App.Version;
            item["username"] = user.Username;
            item["is_active"] = user.IsActive;
            item["notification_url"] = user.NotificationUrl;
            var result = await App.MobileService.InvokeApiAsync("users", item);
            return result.ToObject<User>();
        }

        /// <summary>
        /// Creates a room in the cloud.
        /// </summary>
        /// <param name="roomName">The name of the room being created.</param>
        /// <param name="createdBy">The username of the user creating the room.</param>
        /// <returns>The created <see cref="IRoom"/>.</returns>
        public async Task<IRoom> CreateRoom(string roomName, string createdBy)
        {
            var item = new JObject();
            item["version"] = App.Version;
            item["createdBy"] = createdBy;
            item["roomName"] = roomName;
            var result = await App.MobileService.InvokeApiAsync("rooms", item, HttpMethod.Post, null);
            return result.ToObject<Room>();
        }

        /// <summary>
        /// Join an existing room.
        /// </summary>
        /// <param name="room">The oom to join.</param>
        /// <param name="username">The username of the user joining the specified room.</param>
        public async Task<IRoom> JoinRoom(IRoom room, string username)
        {
            var item = new JObject();
            item["version"] = App.Version;
            item["roomName"] = room.RoomName;
            item["id"] = room.RoomId;
            item["username"] = username;
            var result = await App.MobileService.InvokeApiAsync("usersinrooms", item, HttpMethod.Post, null);
            string[] users = result["users"].Value<string>().Split(new char[]{','}, StringSplitOptions.RemoveEmptyEntries);
            room.UsersInRoom = new List<string>(users);
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
            item.Add("version", App.Version.ToString());
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
        public void SendMessage(IMessage message)
        {
            var item = new  JObject();
            item["version"] = App.Version;
            item["message_type"] = (int)message.Type;
            item["sender"] = message.Sender;
            item["room_id"] = message.RoomId;
            item["content"] = message.Content;

            App.MobileService.InvokeApiAsync("messages", item, HttpMethod.Post, null);
        }
    }
}
