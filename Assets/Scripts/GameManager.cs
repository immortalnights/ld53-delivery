using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private UniverseTimeSO _universeTime;

    private ContractManager _contractManager;

    void Start()
    {
        _contractManager = GetComponent<ContractManager>();
        // _universeTime.HourAction += (DateTime date) => Debug.Log("Hour");
        _universeTime.DayAction += (DateTime date) => Debug.Log("Day");
        _universeTime.YearAction += (DateTime date) => Debug.Log("Year");
    }

    void Update()
    {
        _universeTime.Tick(Time.deltaTime);
    }

    public DateTime Date
    {
        get => _universeTime.Date;
    }
}
