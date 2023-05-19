using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Scriptable Objects/Universe Time")]
public class UniverseTimeSO : ScriptableObject
{
    private DateTime _date;

    private float _interval = 0;
    private float _gameSpeed = 1;

    public event UnityAction<DateTime> HourAction;
    public event UnityAction<DateTime> DayAction;
    public event UnityAction<DateTime> YearAction;

    void OnEnable()
    {
        _gameSpeed = 1;
        _date = new DateTime(2261, 5, 1, 12, 0, 0);
    }

    public DateTime Date
    {
        get => _date;
    }

    public DateTime Tick(float delta)
    {
        _interval += (_gameSpeed * delta);
        while (_interval > 1)
        {
            _interval -= 1;
            var nextDate = _date.AddHours(1);

            if (HourAction != null)
            {
                HourAction.Invoke(nextDate);
            }

            if (_date.Day != nextDate.Day && DayAction != null)
            {
                DayAction.Invoke(nextDate);
            }

            if (_date.Year != nextDate.Year && YearAction != null)
            {
                YearAction.Invoke(nextDate);
            }

            _date = nextDate;
        }

        return _date;
    }

    public string Format()
    {
        return _date.ToString("HH00'h'") + " " + _date.DayOfYear.ToString() + "/" + _date.ToString("yyyy");
    }

    public void IncreaseGameSpeed()
    {
        if (_gameSpeed < 4)
        {
            _gameSpeed *= 2;
        }
    }

    public void DecreaseGameSpeed()
    {
        if (_gameSpeed > 1)
        {
            _gameSpeed /= 2;
        }
    }
}
