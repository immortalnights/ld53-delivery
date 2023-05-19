using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Player Properties")]
public class PlayerPropertiesSO : ScriptableObject
{
    public int credits;

    void Reset()
    {
        credits = 1000;
    }

    // ReceiveCredits
    // PayCredits
}
