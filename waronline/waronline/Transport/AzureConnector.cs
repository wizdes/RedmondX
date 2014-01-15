namespace waronline.Transport
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.WindowsAzure.MobileServices;
    using waronline.Data;

    public class AzureConnector : ICloudConnector
    {
        // <summary>
        /// Creates a user in the cloud.
        /// </summary>
        /// <param name="username">The username of the user being created.</param>
        public void CreateUser(string username)
        {
            AddUserToTable(new User(username));
        }

        private static async void AddUserToTable(User user)
        {
            await Tables.UsersTable.InsertAsync(user);
        }

        /// <summary>
        /// Creates a room in the cloud.
        /// </summary>
        /// <param name="roomName">The name of the room being created.</param>
        /// <returns>The created <see cref="IRoom"/>.</returns>
        public IRoom CreateRoom(string roomName) 
        {

            // TODO: Need to take in the username too.
            return new Room();
        }

        /// <summary>
        /// Join an existing room.
        /// </summary>
        /// <param name="roomName">The name of the room to join.</param>
        /// <param name="username">The username of the user joining the specified room.</param>
        public void JoinRoom(string roomName, string username)
        {
        }

        /// <summary>
        /// View the list of existing rooms.
        /// </summary>
        /// <param name="friendNames">
        /// A list of names of the friends of the current user.
        /// If not null, only the rooms created by these users are returned.
        /// </param>
        /// <returns>A List of rooms currently active.</returns>
        /// <remarks>
        /// Callers must have a try-catch block to handle exception and show and appropriate message to the user.
        /// </remarks>
        public IList<IRoom> ViewRooms(IList<string> friendNames) 
        {
            IList<IRoom> listOfRooms = new List<IRoom>();
            foreach (Room room in GetRooms(friendNames).Result)
            {
                listOfRooms.Add(room);
            }

            return listOfRooms;
            
        }

        private async Task<IList<Room>> GetRooms(IList<string> friendNames)
        {
            if (friendNames != null)
            {
                return await Tables.RoomsTable
                    .Where(x => friendNames.Contains(x.CreatedBy)).ToCollectionAsync();
            }

           return new List<Room> { new Room {RoomName = "Testing"} };
        }

        /// <summary>
        /// Sends a message to other users in the room.
        /// </summary>
        /// <param name="message">The <see cref="IMessage"/> being sent.</param>
        public void SendMessage(IMessage message)
        {
        }
    }
}
