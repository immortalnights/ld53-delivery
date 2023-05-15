using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/Spaceship Channel")]
public class SpaceshipChannelSO : ScriptableObject
{
    public event UnityAction<StationController> DockAction;
    public event UnityAction UndockAction;

    public event UnityAction<float> RefuelAction;

    // Invoked when the Spaceship (player) docks at a station
    public void Docked(StationController station)
    {
        if (DockAction != null)
        {
            DockAction.Invoke(station);
        }
    }

    public void Undocked()
    {
        if (UndockAction != null)
        {
            UndockAction.Invoke();
        }
    }

    public void Refuel(float amount)
    {
        if (RefuelAction != null)
        {
            RefuelAction.Invoke(amount);
        }
    }
}
