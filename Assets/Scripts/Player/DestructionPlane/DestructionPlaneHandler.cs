using UnityEngine;

public class DestructionPlaneHandler : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
}
