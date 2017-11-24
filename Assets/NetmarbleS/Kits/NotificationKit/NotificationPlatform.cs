using UnityEngine;
using System.Collections;

namespace NetmarbleS
{
    public class NotificationPlatform : INotification
    {
        public string VERSION
        {
            get { return "0.0.0.0000"; }
        }


        public int GetNewNotificationCount(string serviceCode)
        {
            return 0;
        }
    }
}