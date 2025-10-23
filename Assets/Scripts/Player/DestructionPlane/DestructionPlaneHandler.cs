using UnityEngine;

public class DestructionPlaneHandler : MonoBehaviour
{
    public PlayerData PlayerData;

    void Start()
    {
        PlayerData = FindFirstObjectByType<PlayerData>();
        if (PlayerData == null)
        {
            Debug.LogError("PlayerData not found in the scene.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        CubesData cubeData = other.GetComponent<CubesData>();
        if (cubeData != null && PlayerData != null)
        {
            PlayerData.AddScore(cubeData.ScoreValue);
            PlayerData.AddXp(cubeData.xpValue);
        }
        Destroy(other.gameObject);
    }
}
