using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField]
    ContactBoardController contactBoard;

    // Start is called before the first frame update
    void Start()
    {
        contactBoard.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void HandleAcceptContract()
    {

    }

    public void ToggleContactBoard(bool visible, StationController station)
    {
        if (visible && station != null) {
            contactBoard.RenderContacts(station.contracts);
            contactBoard.gameObject.SetActive(true);
        } else {
            contactBoard.gameObject.SetActive(false);
        }
    }
}
