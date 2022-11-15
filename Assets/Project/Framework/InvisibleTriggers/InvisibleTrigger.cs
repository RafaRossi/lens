using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InvisibleTrigger : MonoBehaviour
{
    [SerializeField] private bool triggerOnce = true;

    [SerializeField] private UnityEvent trigger = new UnityEvent();

    private void OnTriggerEnter(Collider other)
    {
        trigger?.Invoke();

        if (triggerOnce)
        {
            Destroy(gameObject);
        }
    }
}
