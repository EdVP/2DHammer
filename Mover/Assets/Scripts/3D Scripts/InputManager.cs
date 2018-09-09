using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    public delegate void DirectionInputs();
    public static event DirectionInputs Forward;
    public static event DirectionInputs Backward;
    public static event DirectionInputs Left;
    public static event DirectionInputs Right;
    public static event DirectionInputs Boost;
    public static event DirectionInputs BoostOff;


    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            if (Forward != null) Forward();
        }

        if(Input.GetKey(KeyCode.S))
        {
            if (Backward != null) Backward();
        }
        if(Input.GetKey(KeyCode.A))
        {
            if (Left != null) Left();
        }
        if(Input.GetKey(KeyCode.D))
        {
            if (Right != null) Right();
        }

        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (Boost != null) Boost();
        }
        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            if (BoostOff != null) BoostOff();
        }
    }


    
}
