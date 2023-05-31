using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Unity.XR.CoreUtils;

public class GameManager : MonoBehaviour
{

    public Transform head;
    public Transform origin;
    public Transform target;
    void Start()
    {
        Recenter();
    }

    public void Recenter()
    {
        XROrigin xROrigin = origin.GetComponent<XROrigin>();
        xROrigin.MoveCameraToWorldLocation(target.position);
        xROrigin.MatchOriginUpCameraForward(target.up, target.forward);
    }

  
}
