using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonInfo : MonoBehaviour
{
    public int ItemID;
    public TMP_Text priceText;
    public TMP_Text quantityText;
    public GameObject ShopManager;

    // Update is called once per frame
    void Update()
    {
        priceText.text = "Price: " + ShopManager.GetComponent<VendorManagerScript>().shopItems[2, ItemID].ToString();
        quantityText.text = "Owned: " + ShopManager.GetComponent<VendorManagerScript>().shopItems[3, ItemID].ToString();
    }
}
