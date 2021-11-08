using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardsTextScript : MonoBehaviour
{
    private Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        StartCoroutine(fadeText());
    }


    IEnumerator fadeText()
    {
        Vector3 targetPos = new Vector3(transform.position.x, transform.position.y + 5.0f, 0);
        text.CrossFadeAlpha(0.0f, 2.0f, false);
        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPos, 1.0f * Time.deltaTime);
            yield return null;
        }

        yield return new WaitForSeconds(1.25f);
        Destroy(gameObject);
    }


}
