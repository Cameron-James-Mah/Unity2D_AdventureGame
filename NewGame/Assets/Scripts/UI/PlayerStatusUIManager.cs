using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatusUIManager : MonoBehaviour
{
    public Image[] buffPlaceholders;
    public Sprite[] buffSprites;
    public Sprite[] debuffSprites;
    private Image tempImage; //Used to change alpha of images
    // Start is called before the first frame update
    void Start()
    {
        

        //placeholders[0].sprite = buffSprites[0];
        //placeholders[1].sprite = buffSprites[1];
        foreach (Image i in buffPlaceholders)
        {
            tempImage = i.GetComponent<Image>();
            i.color = new Color(tempImage.color.r, tempImage.color.g, tempImage.color.b, 0.0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    public void AddBuffs(int buffToAdd)
    {
        foreach (Image i in buffPlaceholders)
        {
            if(i.sprite == null)
            {
                i.sprite = buffSprites[buffToAdd];
                tempImage = i.GetComponent<Image>();
                i.color = new Color(tempImage.color.r, tempImage.color.g, tempImage.color.b, 1.0f);
                break;
            }
        }
    }

    public void RemoveBuffs(int buffToRemove)
    {
        foreach (Image i in buffPlaceholders)
        {
            if (i.sprite == buffSprites[buffToRemove])
            {
                i.sprite = null;
                tempImage = i.GetComponent<Image>();
                i.color = new Color(tempImage.color.r, tempImage.color.g, tempImage.color.b, 0.0f);
                //break;
            }
        }

        Image tempIm;
        Image tempIm2;
        //Re Order buffs
        for (int i = 0; i < buffPlaceholders.Length-1; i++)
        {
            tempIm = buffPlaceholders[i].GetComponent<Image>();
            tempIm2 = buffPlaceholders[i+1].GetComponent<Image>();
            if (tempIm.sprite == null && tempIm2.sprite != null)
            {
                tempIm.sprite = tempIm2.sprite;
                tempIm.color = new Color(tempImage.color.r, tempImage.color.g, tempImage.color.b, 1.0f);
                tempIm2.sprite = null;
                tempIm2.color = new Color(tempImage.color.r, tempImage.color.g, tempImage.color.b, 0.0f);
            }
        }   

    }

    public void ClearBuffs()
    {
        foreach(Image i in buffPlaceholders)
        {
            i.sprite = null;
            tempImage = i.GetComponent<Image>();
            i.color = new Color(tempImage.color.r, tempImage.color.g, tempImage.color.b, 0.0f);
        }
    }
}
