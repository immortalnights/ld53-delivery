using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Universe Time")]
public class UniverseTimeSO : ScriptableObject
{
  private DateTime date;

  private float interval = 0;

  void OnEnable()
  {
    date = new DateTime(2261, 5, 1, 12, 0, 0);
  }

  public DateTime Tick(float delta)
  {
    interval += delta;
    while (interval > 1)
    {
      interval -= 1;
      date = date.AddHours(1);
    }

    return date;
  }

  public string Format()
  {
    return date.ToString("dd MMMM yyyy HH00\\h");
  }
}
