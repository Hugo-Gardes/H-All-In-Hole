using UnityEngine;

public class SizeHandler : MonoBehaviour
{
    public float maxScale = 5f;
    public float scaleFactor = 1.0f;
    public PlayerData playerData;

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
        Debug.Log("Current XP: " + playerData.Xp + " | New Scale: " + newScale);
        if (newScale != oldScale)
        {
            oldScale = newScale;
        }
        if (newScale < maxScale)
        {
            transform.localScale = new Vector3(newScale, 1, newScale);
            oldScale = newScale;
        }
    }

}
