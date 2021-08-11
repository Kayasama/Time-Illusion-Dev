using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemInteractable : MonoBehaviour
{

    [SerializeField] public UnityEvent interactEvent;
    [SerializeField] public UnityEvent exitEvent;

    public void InteractWithObject()
    {
        interactEvent.Invoke();
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            InteractWithObject();
        }
    }

    void OnTriggerExit(Collider collider)
    {
        exitEvent.Invoke();
    }
}
