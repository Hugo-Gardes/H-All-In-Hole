using System;
using UnityEngine;
using UnityEngine.AI;

public class ActivatePhysicToTriggeredItem : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Console.WriteLine("triggered ActivatePhysicToTriggeredItem");
        if (other.CompareTag("Item"))
        {
            Console.WriteLine("ActivatePhysicToTriggeredItem: OnTriggerEnter with Item");
            if (other.TryGetComponent<Rigidbody>(out var rb))
            {
                rb.useGravity = true;
            }
        }
    }
}
