using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance { get; private set; } // Singleton instance
    [SerializeField]
    private MaterialData materialData;
    
    private void Awake()
    {
        // Make sure there's only one instance of Inventory
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); // Prevent duplicates
            return;
        }
        
        materialData = SaveData.Load();

    }
    
    public MaterialData GetMaterialData()
    {
        return materialData; // Allow access to MaterialData
    }
    
    public void SaveInventory()
    {
        SaveData.Save(materialData); // Save when needed
    }
}
