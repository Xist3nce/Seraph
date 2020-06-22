using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
    public static PlayerInputManager playerInput;
    public static Vector2 movementVectorNormalized;
    public static bool roll;
    public static bool Fire1;
    public static bool Fire1GBD;




    void Awake()
    {
        if (playerInput != this)
        {
            playerInput = this;
        }
    }


     void Update()
    {
        movementVectorNormalized = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized; //Movement Vector is HorizontalX and VerticalY and is normalized.
        if (Input.GetButtonDown("roll"))
        {
            roll = true;
        }
        if (!Input.GetButtonDown("roll"))
        {
            roll = false;
        }
        if (Input.GetButtonDown("Fire1"))
        {
            Fire1 = true;
        }
        if (Input.GetButton("Fire1"))
        {
            Fire1 = true;
        }
        if (Input.GetButtonUp("Fire1"))
        {
            Fire1 = false;
        }


    }
}
