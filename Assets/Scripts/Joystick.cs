using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Joystick : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    private PlayerJoystick playerMove;

    // Start is called before the first frame update
    void Start()
    {

        playerMove = GameObject.Find("Player").GetComponent<PlayerJoystick>();
    }

    public void OnPointerDown(PointerEventData data)
    {
        if (gameObject.name == "Left")
            playerMove.SetMoveLeft(true);
        else
            playerMove.SetMoveLeft(false);
    }

    public void OnPointerUp(PointerEventData data)
    {
        if (gameObject.name == "Left")
            playerMove.StopMoving();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
