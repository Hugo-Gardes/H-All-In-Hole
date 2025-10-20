using System;
using UnityEngine;

public class ActivatePhysicToTriggeredItem : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            if (other.TryGetComponent<Rigidbody>(out var rb))
            {
                rb.useGravity = true;
            }
        }
    }
}
