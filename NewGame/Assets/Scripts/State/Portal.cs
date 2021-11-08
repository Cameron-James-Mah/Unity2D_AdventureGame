using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public string sceneToLoad;
    private GameObject Player;
    

    
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (SceneManager.GetActiveScene().buildIndex == 0)
            {
                //Debug.Log("Trigger");
                //Player.SetActive(false);
                Player.GetComponent<PlayerController>().sceneTransition = true;
                SceneManager.LoadScene(sceneToLoad);
                //Player.SetActive(true);
            }
            else if(SceneManager.GetActiveScene().buildIndex == 1)
            {
                Debug.Log("2");
            }
        }
    }

    
}
