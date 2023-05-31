using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class KeyboardInput : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
        if (!XRSettings.isDeviceActive)
        {
            Debug.Log("No Headset plugged");
        }
        else if(XRSettings.isDeviceActive&&(XRSettings.loadedDeviceName=="Mock HMD"|| XRSettings.loadedDeviceName == "MockHMD Display"))
        {
            Debug.Log("Using Mock HMD");
        }
        else
        {
            Debug.Log("We Have a headset " + XRSettings.loadedDeviceName);
        }
    }
}