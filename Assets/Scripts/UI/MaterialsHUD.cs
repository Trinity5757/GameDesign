using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MaterialsHUD : MonoBehaviour
{
    public TextMeshProUGUI organicText;
    public TextMeshProUGUI metalText;
    public TextMeshProUGUI plasticText;
    public TextMeshProUGUI glassText;

    public static MaterialsHUD instance;

    private void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // TODO: Grab the inventory instance and update the material counts displayed

   /* private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("Updating material hud!");
            UpdateMaterialHUD();
        }
    }*/

    public void UpdateMaterialHUD()
    {
        organicText.text = "Organic: " + Inventory.Instance.GetMaterialData().organic;
        metalText.text = "Metal: " + Inventory.Instance.GetMaterialData().metal;
        plasticText.text = "Plastic: " + Inventory.Instance.GetMaterialData().plastic;
        glassText.text = "Glass: " + Inventory.Instance.GetMaterialData().glass;
    }

}
