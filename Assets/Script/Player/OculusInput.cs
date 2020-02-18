using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class OculusInput : MonoBehaviour
{

    public SteamVR_Action_Vector2 joyStickAction;

    private void Update()
    {
        if (SteamVR_Actions._default.GrabPinch.GetStateDown(SteamVR_Input_Sources.Any))
        {
            print("Open");
        }

        Vector2 joyStickValue = joyStickAction.GetAxis(SteamVR_Input_Sources.Any);

        if(joyStickValue != Vector2.zero)
        {
            print(joyStickValue);
        }
    }
}
