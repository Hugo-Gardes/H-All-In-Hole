using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class inv : MonoBehaviour
{
    public GameObject inventaire1;
    public GameObject prefabItem;

    private short cornNumbers = 0;
    private short treeNumbers = 0;
    private short wallNumbers = 0;

    void Start()
    {
        if (PlayerPrefs.HasKey("CornNumbers"))
        {
            cornNumbers = (short)PlayerPrefs.GetInt("CornNumbers");
        }
        else
        {
            PlayerPrefs.SetInt("CornNumbers", cornNumbers);
        }

        if (PlayerPrefs.HasKey("TreeNumbers"))
        {
            treeNumbers = (short)PlayerPrefs.GetInt("TreeNumbers");
        }
        else
        {
            PlayerPrefs.SetInt("TreeNumbers", treeNumbers);
        }

        if (PlayerPrefs.HasKey("WallNumbers"))
        {
            wallNumbers = (short)PlayerPrefs.GetInt("WallNumbers");
        }
        else
        {
            PlayerPrefs.SetInt("WallNumbers", wallNumbers);
        }
        updateInv();
    }

    private void updateInv()
    {
        GameObject corn;
        GameObject tree;
        GameObject wall;

        foreach (Transform child in inventaire1.transform)
        {
            Destroy(child.gameObject);
        }

        corn = Instantiate(prefabItem, inventaire1.transform);
        corn.name = "corn";
        corn.GetComponentInChildren<TMP_Text>().text = cornNumbers.ToString();
        SetItemImage(corn, "images/Selection/items/cone");


        tree = Instantiate(prefabItem, inventaire1.transform);
        tree.name = "tree";
        tree.GetComponentInChildren<TMP_Text>().text = treeNumbers.ToString();
        SetItemImage(tree, "images/Selection/items/tree");

        wall = Instantiate(prefabItem, inventaire1.transform);
        wall.name = "wall";
        wall.GetComponentInChildren<TMP_Text>().text = wallNumbers.ToString();
        SetItemImage(wall, "images/Selection/items/wall");
    }

    private void SetItemImage(GameObject item, string spritePath)
    {
        Sprite sprite = Resources.Load<Sprite>(spritePath);
        if (sprite == null)
        {
            Debug.LogError($"Sprite not found at path: {spritePath}");
            return;
        }

        Image image = item.GetComponentInChildren<Image>();
        if (image != null)
        {
            image.sprite = sprite;
        }
        else
        {
            Debug.LogError($"No Image component found in children of {item.name}");
        }
    }
}
