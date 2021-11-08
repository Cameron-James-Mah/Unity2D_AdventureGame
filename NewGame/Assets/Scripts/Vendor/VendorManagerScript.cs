using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class VendorManagerScript : MonoBehaviour
{

    public int[,] shopItems = new int[6, 6]; //Column one is ID
    public TMP_Text goldText;
    public GameObject shopObject;


    // Start is called before the first frame update
    void Start()
    {
        goldText.text = "Gold: " + InventoryManager.gold.ToString();

        //ID's
        shopItems[1, 1] = 1;
        shopItems[1, 2] = 2;
        shopItems[1, 3] = 3;
        shopItems[1, 4] = 4;

        //Price
        shopItems[2, 1] = 10;
        shopItems[2, 2] = 10;
        shopItems[2, 3] = 20;
        shopItems[2, 4] = 20;


        //Owned
        shopItems[3, 1] = InventoryManager.healthPots;
        shopItems[3, 2] = InventoryManager.manaPots;
        shopItems[3, 3] = InventoryManager.partyHealthPots;
        shopItems[3, 4] = InventoryManager.partyManaPots;

        //Purchase limit   **Not yet implemented
        shopItems[4, 1] = 0;
        shopItems[4, 2] = 0;
        shopItems[4, 3] = 0;
        shopItems[4, 4] = 0;
    }

    // Update is called once per frame
    void Update()
    {
        goldText.text = "Gold: " + InventoryManager.gold.ToString();
    }

    public void Buy()
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;
        if(InventoryManager.gold >= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID])
        {
            InventoryManager.gold -= shopItems[2, ButtonRef.GetComponent<ButtonInfo>().ItemID];
            //Debug.Log(InventoryManager.gold);
            shopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID]++;
            goldText.text = "Gold: " + InventoryManager.gold.ToString();
            ButtonRef.GetComponent<ButtonInfo>().quantityText.text = shopItems[3, ButtonRef.GetComponent<ButtonInfo>().ItemID].ToString();
            if(ButtonRef.GetComponent<ButtonInfo>().ItemID == 1)
            {
                //Debug.Log("Hp");
                InventoryManager.healthPots++;
            }
            else if (ButtonRef.GetComponent<ButtonInfo>().ItemID == 2)
            {
                //Debug.Log("Hp");
                InventoryManager.manaPots++;
            }
            else if (ButtonRef.GetComponent<ButtonInfo>().ItemID == 3)
            {
                //Debug.Log("Hp");
                InventoryManager.partyHealthPots++;
            }
            else if (ButtonRef.GetComponent<ButtonInfo>().ItemID == 4)
            {
                //Debug.Log("Hp");
                InventoryManager.partyManaPots++;
            }
        }
    }

    public void HideShop()
    {
        shopObject.SetActive(false);
        StateController.paused = false;
    }

    
}
