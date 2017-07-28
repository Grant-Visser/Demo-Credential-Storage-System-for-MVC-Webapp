using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace CredentialStorageApplication.Models.Helper_Class
{
    class PasswordManagement
    {
        private static PasswordManagement uniqueInstance;
        private static object syncRoot = new object();

        private PasswordManagement()
        {
            //Private default constructor. Because you WILL use my method to create a new instance of this class. Therefore only 1 can exist at a time.
        }

        public static PasswordManagement getInstance()//Singleton constructor
        {
            if (uniqueInstance == null)
            {
                lock (syncRoot) //For threadsafe operation I use a dummy object that can be locked without consequence.
                {
                    if (uniqueInstance == null)
                    {
                        uniqueInstance = new PasswordManagement();
                    }
                }
            }
            return uniqueInstance;
        }

        public string getValue(string key)
        {
            try
            {
                var config = System.Web.Configuration.WebConfigurationManager.AppSettings;
                var keyarray = config.AllKeys;
                bool found = false;
                foreach (string s in keyarray)
                {
                    if (s == key)
                    {
                        found = true;
                    }
                }
                if (found)
                {
                    var output = config.Get(key); //Returns the value associated with the Key
                    return output;
                }
                else
                {
                    Debug.WriteLine("IMPORTANT: You're a muppet. The Key: " + key + " doesn't exist in the Appsettings file");
                    return "Nope. Key doesn't exist";
                }
                
            }
            catch (Exception e)
            {
                Debug.WriteLine("IMPORTANT " + e);
                throw;
            }
        }

    }
}