using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoldCounterUI : MonoBehaviour
{
    private TMP_Text goldCounter;
    void Start()
    {
        goldCounter = GetComponent<TMP_Text>();
    }
    void Update()
    {
        goldCounter.text = "Gold: " + InventoryManager.gold;
    }
}
