using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MpPotCounter : MonoBehaviour
{
    private TMP_Text counter;
    // Start is called before the first frame update
    void Start()
    {
        counter = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        counter.text = InventoryManager.manaPots.ToString();
    }
}
