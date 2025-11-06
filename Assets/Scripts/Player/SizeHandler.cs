using UnityEngine;

public class SizeHandler : MonoBehaviour
{
    public float maxScale = 5f;
    public float scaleFactor = 1.0f;
    public PlayerData playerData;
    public GameObject colliderObject;

    private float oldScale = 1f;

    void Start()
    {
        if (playerData == null)
        {
            playerData = gameObject.GetComponent<PlayerData>();
            if (playerData == null)
            {
                Debug.LogError("PlayerData component not found on the player object.");
            }
        }

        oldScale = transform.localScale.x;
    }

    void Update()
    {
        float newScale = scaleFactor + playerData.Xp / 100f;
        if (newScale != oldScale)
        {
            oldScale = newScale;
        } else
        {
            return;
        }
        if (newScale > maxScale)
        {
            newScale = maxScale;
        }
        transform.localScale = new Vector3(newScale, 1, newScale);
        colliderObject.transform.localScale = new Vector3(colliderObject.transform.localScale.x, colliderObject.transform.localScale.x, colliderObject.transform.localScale.z);
        oldScale = newScale;
    }

}
