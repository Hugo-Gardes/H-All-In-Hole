using UnityEngine;

public class MapLoader : MonoBehaviour
{
    void Start()
    {
        LoadMap("TestMap");
    }

    public void LoadMap(string mapName)
    {
        ItemsWrapper itemsData = JsonUtility.FromJson<ItemsWrapper>(System.IO.File.ReadAllText(Application.dataPath + "/Maps/" + mapName + ".json"));
        foreach (var itemData in itemsData.Items)
        {
            GameObject prefab = Resources.Load<GameObject>("Prefab/" + itemData.PrefabName);
            if (prefab == null)
            {
                Debug.LogError($"Prefab {itemData.PrefabName} not found");
                continue;
            }

            GameObject itemInstance = Instantiate(prefab);
            itemInstance.transform.position = new Vector3(itemData.PositionX, itemData.PositionY, itemData.PositionZ);
            itemInstance.transform.rotation = Quaternion.Euler(itemData.RotationX, itemData.RotationY, itemData.RotationZ);
            itemInstance.transform.localScale = new Vector3(itemData.ScaleX, itemData.ScaleY, itemData.ScaleZ);
        }
    }
}
