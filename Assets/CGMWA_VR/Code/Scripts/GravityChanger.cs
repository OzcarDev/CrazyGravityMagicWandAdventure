using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.Utilities.Editor;
using UnityEngine;

public class GravityChanger : MonoBehaviour
{
    public static GravityChanger Instance { get; private set; }
    
    

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    
}
