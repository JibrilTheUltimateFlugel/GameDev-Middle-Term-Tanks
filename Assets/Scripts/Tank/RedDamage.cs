using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class RedDamage : MonoBehaviour
{
    public UnityEvent OnPlayerDamage;
    private void OnTriggerEnter(Collider other)
    {
       if(other.CompareTag("Shell"))
        {
            OnPlayerDamage.Invoke(); //Invoke the event
        }
    }
}
