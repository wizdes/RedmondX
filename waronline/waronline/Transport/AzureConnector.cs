using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using waronline.Game;

namespace waronline.Transport
{
    public class AzureConnector : ICloud
    {
        // <summary>
        /// Creates a user in the cloud.
        /// </summary>
        /// <param name="username">The username of the user being created.</param>
        public void CreateUser(string username)
        {
        }

        /// <summary>
        /// Creates a room in the cloud.
        /// </summary>
        /// <param name="roomName">The name of the room being created.</param>
        /// <returns>The created <see cref="IRoom"/>.</returns>
        public IRoom CreateRoom(string roomName) 
        {
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
        /// <returns></returns>
        public IList<IRoom> ViewRooms(IList<string> friendNames) 
        {
            return new List<IRoom>();
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
