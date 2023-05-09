using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Spaceships/Engine")]
public class EngineScriptableObject : ScriptableObject
{
  public float thrust;
  public float speed;

  void Awake()
  {
    // Debug.Log("Engine Awake");
  }

  void OnDestroy()
  {
    // Debug.Log("Engine OnDestroy");
  }

  void OnDisable()
  {
    // Debug.Log("Engine OnDisable");
  }

  void OnEnable()
  {
    // Debug.Log("Engine OnEnable");
  }

  void OnValidate()
  {
    // Debug.Log("Engine OnValidate");
  }

  void Reset()
  {
    // Debug.Log("Engine Reset");
  }
}
