using System;
using UnityEngine;

public class ActivatePhysicToTriggeredItem : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            if (other.TryGetComponent<CubesData>(out var cubesData))
            {
                float parentSize = gameObject.transform.parent.localScale.x;
                if (parentSize < cubesData.minSizeEatable)
                {
                    return;
                }
            }
            if (other.TryGetComponent<Rigidbody>(out var rb))
            {
                rb.useGravity = true;
            }
        }
    }
}
