using UnityEngine;

public class cameraPosition : MonoBehaviour
{
    public GameObject player;
    public float distanceMultiplier = 15f;
    public float heightMultiplier = 10f;
    public float cameraAngle = 45f;
    [Range(0.01f, 1f)]
    public float followSpeed = 0.1f;
    private Vector3 initialPlayerScale;
    private Vector3 targetPosition;
    private Quaternion targetRotation;

    void Start()
    {
        if (player != null)
        {
            initialPlayerScale = player.transform.localScale;
            UpdateCamera();
        }
    }

    void LateUpdate()
    {
        if (player != null)
        {
            UpdateCamera();
        }
    }

    public void UpdateCamera()
    {
        if (player == null) return;
        float scaleFactor = player.transform.localScale.magnitude / initialPlayerScale.magnitude;
        float adjustedDistance = distanceMultiplier * scaleFactor;
        float adjustedHeight = heightMultiplier * scaleFactor;
        float angleInRadians = cameraAngle * Mathf.Deg2Rad;
        float horizontalDistance = adjustedDistance * Mathf.Cos(angleInRadians);
        float verticalDistance = adjustedHeight + (adjustedDistance * Mathf.Sin(angleInRadians));

        Vector3 offset = new Vector3(0, verticalDistance, -horizontalDistance);
        targetPosition = player.transform.position + offset;
        Vector3 directionToPlayer = player.transform.position - targetPosition;
        targetRotation = Quaternion.LookRotation(directionToPlayer, Vector3.up);
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, followSpeed);
    }

    public void ResetReferenceScale()
    {
        if (player != null)
        {
            initialPlayerScale = player.transform.localScale;
        }
    }
}
