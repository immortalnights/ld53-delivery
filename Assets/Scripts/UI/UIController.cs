using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private ContactBoardController contactBoard;

    // Start is called before the first frame update
    void Start()
    {
        contactBoard.gameObject.SetActive(false);
    }
}
