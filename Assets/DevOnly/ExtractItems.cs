using System.Collections.Generic;
using UnityEngine;

public class ExtractItems : MonoBehaviour
{
    private GameObject[] items;
    private ItemsWrapper savableItems = new();

    void Start()
    {
        items = GameObject.FindGameObjectsWithTag("Item");
        Debug.Log($"Found {items.Length} items in the scene.");
        ConvertToSavable();
        SaveToJson();
    }

    private void ConvertToSavable()
    {
        foreach (var item in items)
        {
            if (!item.TryGetComponent<CubesData>(out var cubeData))
            {
                Debug.LogWarning($"Item {item.name} does not have a CubesData component. Skipping.");
                continue;
            }

            SerializableItem serializableItem = new SerializableItem
            {
                PositionX = item.transform.position.x,
                PositionY = item.transform.position.y,
                PositionZ = item.transform.position.z,
                RotationX = item.transform.rotation.eulerAngles.x,
                RotationY = item.transform.rotation.eulerAngles.y,
                RotationZ = item.transform.rotation.eulerAngles.z,
                ScaleX = item.transform.localScale.x,
                ScaleY = item.transform.localScale.y,
                ScaleZ = item.transform.localScale.z,
                PrefabName = cubeData.PrefabName
            };
            savableItems.Items.Add(serializableItem);
        }
    }

    private void SaveToJson()
    {
        Debug.Log(savableItems.Items.Count);
        string json = JsonUtility.ToJson(savableItems, true);
        Debug.Log($"Saving items to JSON: {json}");
        System.IO.File.WriteAllText(Application.dataPath + "/DevOnly/ItemsData.json", json);
    }
}
