namespace waronline.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.WindowsAzure.MobileServices;
    using Newtonsoft.Json;

    class User
    {
        /// <summary>
        /// Gets or sets the user id.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        [JsonProperty(PropertyName = "username")]
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the notification url (channel) for current device used by the user.
        /// </summary>
        [JsonProperty(PropertyName = "notification_url")]
        public string NotificationUrl { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether a user is currently active.
        /// </summary>
        [JsonProperty(PropertyName = "is_active")]
        public bool IsActive { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        /// <param name="username">The username of the user being creatd.</param>
        public User(string username)
        {
            this.Username = username;
        }
    }
}
