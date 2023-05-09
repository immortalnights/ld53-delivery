using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Events/Station Screen Channel")]
public class StationScreenChannelSO : ScriptableObject
{
  public event UnityAction<Screen> ChangeScreenAction = default;

  public void Invoke(Screen screen)
  {
    ChangeScreenAction.Invoke(screen);
  }
}
