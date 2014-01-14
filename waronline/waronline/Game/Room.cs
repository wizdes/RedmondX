using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace waronline.Game
{
    public class Room : IRoom
    {
        /// <summary>
        /// Gets or sets the room id.
        /// </summary>
        public string RoomId { get; set; }

        /// <summary>
        /// Gets or sets the name of the room.
        /// </summary>
        public string RoomName { get; set; }

        /// <summary>
        /// Gets or sets the username of the creator of the room.
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the list of users present in the room.
        /// </summary>
        public IList<string> UsersInRoom { get; set; }
    }
}
