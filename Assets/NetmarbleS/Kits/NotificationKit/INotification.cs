using UnityEngine;
using System.Collections;

namespace NetmarbleS
{
    public interface INotification
    {
        string VERSION { get; }
        int GetNewNotificationCount(string serviceCode);
    }
}