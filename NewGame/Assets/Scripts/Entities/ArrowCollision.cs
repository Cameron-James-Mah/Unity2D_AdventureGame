using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowCollision : MonoBehaviour
{
    public LayerMask enemyLayers;
    public int arrowDmg;
    public bool cripplingShot;
    public int cripplingShotDuration = 2;
    public bool markOnHit = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DamageDropOff());
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, 1.3f, enemyLayers);
        //Debug.Log(hitEnemies.Length);
        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemy.gameObject.layer == LayerMask.NameToLayer("Slime"))
            {
                enemy.GetComponent<testSlime>().Hit(arrowDmg);
                if (cripplingShot == true)
                {
                    enemy.GetComponent<testSlime>().CripplingShot(cripplingShotDuration);
                }
                if (markOnHit == true)
                {
                    enemy.GetComponent<testSlime>().Marked(cripplingShotDuration);
                }
            }
            else if (enemy.gameObject.layer == LayerMask.NameToLayer("Goblin1"))
            {
                enemy.GetComponent<Goblin1Script>().Hit(arrowDmg);
                if (cripplingShot == true)
                {
                    enemy.GetComponent<Goblin1Script>().CripplingShot(cripplingShotDuration);
                }
                if (markOnHit == true)
                {
                    enemy.GetComponent<Goblin1Script>().Marked(cripplingShotDuration);
                }
            }
            else if (enemy.gameObject.layer == LayerMask.NameToLayer("Goblin2"))
            {
                enemy.GetComponent<Goblin2Script>().Hit(arrowDmg);
                if (cripplingShot == true)
                {
                    enemy.GetComponent<Goblin2Script>().CripplingShot(cripplingShotDuration);
                }
                if (markOnHit == true)
                {
                    enemy.GetComponent<Goblin2Script>().Marked(cripplingShotDuration);
                }
            }
            else if (enemy.gameObject.layer == LayerMask.NameToLayer("Worm"))
            {
                enemy.GetComponent<WormScript>().Hit(arrowDmg);
                if (cripplingShot == true)
                {
                    enemy.GetComponent<WormScript>().CripplingShot(cripplingShotDuration);
                }
                if (markOnHit == true)
                {
                    enemy.GetComponent<WormScript>().Marked(cripplingShotDuration);
                }
            }
            else if (enemy.gameObject.layer == LayerMask.NameToLayer("Skeleton"))
            {
                enemy.GetComponent<SkeletonScript>().Hit(arrowDmg);
                if (cripplingShot == true)
                {
                    enemy.GetComponent<SkeletonScript>().CripplingShot(cripplingShotDuration);
                }
                if (markOnHit == true)
                {
                    enemy.GetComponent<SkeletonScript>().Marked(cripplingShotDuration);
                }
            }
            else if (enemy.gameObject.layer == LayerMask.NameToLayer("Orc1"))
            {
                enemy.GetComponent<Orc1Script>().Hit(arrowDmg);
                if (cripplingShot == true)
                {
                    enemy.GetComponent<Orc1Script>().CripplingShot(cripplingShotDuration);
                }
                if (markOnHit == true)
                {
                    enemy.GetComponent<Orc1Script>().Marked(cripplingShotDuration);
                }
            }
            else if (enemy.gameObject.layer == LayerMask.NameToLayer("Orc2"))
            {
                //Debug.Log("g");
                enemy.GetComponent<Orc2Script>().Hit(arrowDmg);
                if (cripplingShot == true)
                {
                    enemy.GetComponent<Orc2Script>().CripplingShot(cripplingShotDuration);
                }
                if (markOnHit == true)
                {
                    enemy.GetComponent<Orc2Script>().Marked(cripplingShotDuration);
                }
            }
            else if (enemy.gameObject.layer == LayerMask.NameToLayer("Statue"))
            {
                enemy.GetComponent<StatueScript>().Hit(arrowDmg);
                if (cripplingShot == true)
                {
                    enemy.GetComponent<StatueScript>().CripplingShot(cripplingShotDuration);
                }
                if (markOnHit == true)
                {
                    enemy.GetComponent<StatueScript>().Marked(cripplingShotDuration);
                }
            }
            else if (enemy.gameObject.layer == LayerMask.NameToLayer("Minotaur"))
            {
                enemy.GetComponent<MinotaurScript>().Hit(arrowDmg);
                if (cripplingShot == true)
                {
                    enemy.GetComponent<MinotaurScript>().CripplingShot(cripplingShotDuration);
                }
                if (markOnHit == true)
                {
                    enemy.GetComponent<MinotaurScript>().Marked(cripplingShotDuration);
                }
            }
        }
        Destroy(gameObject);
    }

    IEnumerator DamageDropOff()
    {
        while (gameObject != null)
        {
            arrowDmg -= 5;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
//