using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace waronline.Data
{
    /// <summary>
    /// A class that can be used to persists key-value pairs.
    /// </summary>
    public class PersistentStorage
    {
        private IsolatedStorageSettings settings;

        private const string UsernameKey = "Username";

        private const string UserIdKey = "UserId";

        private string DefaultUsername = null;

        private static PersistentStorage instance;

        private PersistentStorage()
        {
            settings = IsolatedStorageSettings.ApplicationSettings;
        }

        public static PersistentStorage Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PersistentStorage();
                }

                return instance;
            }
        }

        public string Username
        {
            get
            {
                return GetValueOrDefault<string>(UsernameKey, DefaultUsername);
            }

            set
            {
                if (AddOrUpdateValue(UsernameKey, value))
                {
                    Save();
                }
            }
        }

        public string UserId
        {
            get
            {
                return GetValueOrDefault<string>(UserIdKey, null);
            }

            set
            {
                if (AddOrUpdateValue(UserIdKey, value))
                {
                    Save();
                }
            }
        }

        public bool AddOrUpdateValue(string Key, Object value)
        {
            bool valueChanged = false;

            // If the key exists
            if (settings.Contains(Key))
            {
                // If the value has changed
                if (settings[Key] != value)
                {
                    // Store the new value
                    settings[Key] = value;
                    valueChanged = true;
                }
            }
            // Otherwise create the key.
            else
            {
                settings.Add(Key, value);
                valueChanged = true;
            }

            return valueChanged;
        }

        /// <summary>
        /// Get the current value of the setting, or if it is not found, set the 
        /// setting to the default setting.
        /// </summary>
        /// <typeparam name="T">The type of the value.</typeparam>
        /// <param name="Key">The name of the key for which the value should be retrieved.</param>
        /// <param name="defaultValue">
        /// A default value for the key that should be returned if the key does not exists in the local store.
        /// </param>
        /// <returns>
        /// The value of the key if it exists in the local store; <paramref name="defaultValue"/> otherwise.
        /// </returns>
        public T GetValueOrDefault<T>(string Key, T defaultValue)
        {
            T value;

            // If the key exists, retrieve the value.
            if (settings.Contains(Key))
            {
                value = (T)settings[Key];
            }
            // Otherwise, use the default value.
            else
            {
                value = defaultValue;
            }
            return value;
        }

        /// <summary>
        /// Save the settings.
        /// </summary>
        public void Save()
        {
            settings.Save();
        }
    }
}
