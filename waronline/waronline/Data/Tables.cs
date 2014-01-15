namespace waronline.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.WindowsAzure.MobileServices;
    using Newtonsoft.Json;

    static class Tables
    {
        /// <summary>
        /// Table that stores the user details.
        /// </summary>
        private static IMobileServiceTable<User> usersTable = App.MobileService.GetTable<User>();

        /// <summary>
        /// Gets the table storing user details.
        /// </summary>
        public static IMobileServiceTable<User> UsersTable
        {
            get
            {
                return usersTable;
            }
        }

        /// <summary>
        /// Table that stores messages sent between users.
        /// </summary>
        private static IMobileServiceTable<Message> messagesTable = App.MobileService.GetTable<Message>();

        /// <summary>
        /// Gets the table that stores messages sent between users.
        /// </summary>
        public static IMobileServiceTable<Message> MessagesTable
        {
            get
            {
                return messagesTable;
            }
        }

        /// <summary>
        /// Table that stores the details of all the rooms.
        /// </summary>
        private static IMobileServiceTable<Room> roomsTable = App.MobileService.GetTable<Room>();

        /// <summary>
        /// Gets or sets the table that stores the details of all the rooms.
        /// </summary>
        public static IMobileServiceTable<Room> RoomsTable
        {
            get
            {
                return roomsTable;
            }
        }        
    }
}
