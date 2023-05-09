using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/Void Event")]
public class VoidEventChannelSO : ScriptableObject
{
  public UnityAction OnEventRaised;

  public void RaiseEvent()
  {
    if (OnEventRaised != null)
    {
      OnEventRaised.Invoke();
    }
  }
}
