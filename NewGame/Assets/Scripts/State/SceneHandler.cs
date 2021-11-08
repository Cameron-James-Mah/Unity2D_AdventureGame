using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneHandler : MonoBehaviour
{
    private GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        Player.transform.position = new Vector2(0, -5);
        Player.GetComponent<PlayerController>().sceneTransition = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
