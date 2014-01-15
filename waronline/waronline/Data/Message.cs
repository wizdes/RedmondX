namespace waronline.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;

    public class Message : IMessage
    {
        /// <summary>
        /// Gets or sets the type of the message.
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public MessageType Type { get; set; }

        /// <summary>
        /// Gets or sets the content of the message.
        /// </summary>
        [JsonProperty(PropertyName = "content")]
        public string Content { get; set; }

        /// <summary>
        /// Gets or sets the username of sender of the message.
        /// </summary>
        [JsonProperty(PropertyName = "sender")]
        public string Sender { get; set; }

        /// <summary>
        /// Gets or sets the id of the room to send the message to.
        /// </summary>
        [JsonProperty(PropertyName = "room_id")]
        public string RoomId { get; set; }
    }
}
