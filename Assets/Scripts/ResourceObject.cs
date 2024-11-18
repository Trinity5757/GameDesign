using UnityEngine;

public enum ResourceType
{
    Metal,
    Glass,
    Plastic,
    Organic
}

public class ResourceObject : MonoBehaviour
{
    public ResourceType resourceType; // Set this in prefab
    public int resourceAmount = 10;   // Set the amount in prefab

    private MaterialData _materials;

    public void Interact()
    {
        _materials = Inventory.Instance.GetMaterialData();
        
        switch (resourceType)
        {
            case ResourceType.Metal:
                _materials.AddMetal(resourceAmount);
                break;
            case ResourceType.Glass:
                _materials.AddGlass(resourceAmount);
                break;
            case ResourceType.Plastic:
                _materials.AddPlastic(resourceAmount);
                break;
            case ResourceType.Organic:
                _materials.AddOrganic(resourceAmount);
                break;
            default:
                Debug.LogError("Unknown material type: " + resourceType);
                break;
        }
        //Debug.Log("Metal Amount: " + _materials.metal);
        Inventory.Instance.SaveInventory();

    }
}
