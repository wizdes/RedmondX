namespace waronline.Transport
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using waronline.Data;

    public interface ICloudConnector
    {
        /// <summary>
        /// Creates a user in the cloud.
        /// </summary>
        /// <param name="username">The username of the user being created.</param>
        void CreateUser(string username);

        /// <summary>
        /// Creates a room in the cloud.
        /// </summary>
        /// <param name="roomName">The name of the room being created.</param>
        Task CreateRoom(string roomName, string createdBy);

        /// <summary>
        /// Join an existing room.
        /// </summary>
        /// <param name="roomName">The name of the room to join.</param>
        /// <param name="username">The username of the user joining the specified room.</param>
        Task<IRoom> JoinRoom(string roomName, string username);

        /// <summary>
        /// View the list of existing rooms.
        /// </summary>
        /// <param name="friendNames">
        /// A list of names of the friends of the current user.
        /// If not null, only the rooms created by these users are returned.
        /// </param>
        /// <returns></returns>
        Task<IList<IRoom>> ViewRooms(IList<string> friendNames);

        /// <summary>
        /// Sends a message to other users in the room.
        /// </summary>
        /// <param name="message">The <see cref="IMessage"/> being sent.</param>
        void SendMessage(IMessage message);
    }
}
