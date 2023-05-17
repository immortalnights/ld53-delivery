using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/Station Screen Channel")]
public class StationScreenChannelSO : ScriptableObject
{
    public event UnityAction<StationScreen> ChangeScreenAction = default;

    public void Invoke(StationScreen screen)
    {
        ChangeScreenAction.Invoke(screen);
    }
}
