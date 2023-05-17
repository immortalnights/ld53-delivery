using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/Notification")]
public class NotificationChannelSO : ScriptableObject
{
    public event UnityAction<string, int> NotificationAction;

    public void Send(string text, int duration = -1)
    {
        if (NotificationAction != null)
        {
            NotificationAction.Invoke(text, duration);
        }
    }
}
