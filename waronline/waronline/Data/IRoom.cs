﻿namespace waronline.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IRoom
    {
        /// <summary>
        /// Gets or sets the room id.
        /// </summary>
        string RoomId { get; set; }

        /// <summary>
        /// Gets or sets the name of the room.
        /// </summary>
        string RoomName { get; set; }

        /// <summary>
        /// Gets or sets the username of the creator of the room.
        /// </summary>
        string CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the list of users present in the room.
        /// </summary>
        IList<string> UsersInRoom { get; set; }
    }
}
