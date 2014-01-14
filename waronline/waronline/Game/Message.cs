using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace waronline.Game
{
    public class Message : IMessage
    {
        /// <summary>
        /// Gets or sets the type of the message.
        /// </summary>
        public MessageType Type { get; set; }

        /// <summary>
        /// Gets or sets the content of the message.
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Gets or sets the username of sender of the message.
        /// </summary>
        public string Sender { get; set; }

        /// <summary>
        /// Gets or sets the id of the room to send the message to.
        /// </summary>
        public string RoomId { get; set; }
    }
}
