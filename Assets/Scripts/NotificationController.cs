using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NotificationController : MonoBehaviour
{

    [SerializeField] private Transform _notificationContainer;
    [SerializeField] private TMP_Text _textField;
    [SerializeField] private NotificationChannelSO _notificationChannel;


    void Start()
    {
        _notificationChannel.NotificationAction += HandleNotification;
        _notificationContainer.gameObject.SetActive(false);
    }

    void Update()
    {
    }

    private void HandleNotification(string text, int duration)
    {
        StartCoroutine(DisplayNotification(text, duration));
    }

    IEnumerator DisplayNotification(string text, int duration)
    {
        // default to three seconds of display
        // FIXME, need to handle multiple notifications...
        var realDuration = duration == -1 ? 3 : duration;

        _notificationContainer.gameObject.SetActive(true);
        _textField.text = text;
        yield return new WaitForSecondsRealtime(realDuration);
        _textField.text = "";
        _notificationContainer.gameObject.SetActive(false);
    }
}
