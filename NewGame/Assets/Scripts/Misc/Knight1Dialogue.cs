using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Knight1Dialogue : MonoBehaviour
{
    public GameObject textBox;
    public TMP_Text dialogueText;

    void Start()
    {

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            textBox.SetActive(true);
            dialogueText.text = "Knight: Our village is under attack, go outside and help!";
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            textBox.SetActive(false);
        }
    }
}
