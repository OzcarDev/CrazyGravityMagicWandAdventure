using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Lever : MonoBehaviour
{

    public UnityEvent OnTrigger;
    public UnityEvent OnUnTrigger;
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Lever"))
        {
            OnTrigger.Invoke();
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Lever"))
        {
            OnUnTrigger.Invoke();
        }
    }
}
