using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardVendor : MonoBehaviour
{
    public GameObject player;
    public GameObject shopObject;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            float distToChar = Vector3.Distance(player.transform.position, transform.position);
            if(distToChar <= 2.0f)
            {
                StateController.paused = true;
                //Debug.Log("Here");
                shopObject.SetActive(true);
            }


        }
    }
}
