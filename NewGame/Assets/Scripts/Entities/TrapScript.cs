using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapScript : MonoBehaviour
{
    public int rootDuration;
    public int markDuration;
    public LayerMask enemyLayers;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, 0.8f, enemyLayers);
        //Debug.Log(hitEnemies.Length);
        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemy.gameObject.layer == LayerMask.NameToLayer("Slime"))
            {
                enemy.GetComponent<testSlime>().Rooted(rootDuration);
                enemy.GetComponent<testSlime>().Marked(markDuration);
            }
            else if(enemy.gameObject.layer == LayerMask.NameToLayer("Goblin1"))
            {
                enemy.GetComponent<Goblin1Script>().Rooted(rootDuration);
                enemy.GetComponent<Goblin1Script>().Marked(markDuration);
            }
            else if (enemy.gameObject.layer == LayerMask.NameToLayer("Goblin2"))
            {
                enemy.GetComponent<Goblin2Script>().Rooted(rootDuration);
                enemy.GetComponent<Goblin2Script>().Marked(markDuration);
            }
            else if (enemy.gameObject.layer == LayerMask.NameToLayer("Worm"))
            {
                enemy.GetComponent<WormScript>().Rooted(rootDuration);
                enemy.GetComponent<WormScript>().Marked(markDuration);
            }
            else if (enemy.gameObject.layer == LayerMask.NameToLayer("Skeleton"))
            {
                enemy.GetComponent<SkeletonScript>().Rooted(rootDuration);
                enemy.GetComponent<SkeletonScript>().Marked(markDuration);
            }
            else if (enemy.gameObject.layer == LayerMask.NameToLayer("Orc1"))
            {
                enemy.GetComponent<Orc1Script>().Rooted(rootDuration);
                enemy.GetComponent<Orc1Script>().Marked(markDuration);
            }
            else if (enemy.gameObject.layer == LayerMask.NameToLayer("Orc2"))
            {
                enemy.GetComponent<Orc2Script>().Rooted(rootDuration);
                enemy.GetComponent<Orc2Script>().Marked(markDuration);
            }
            else if (enemy.gameObject.layer == LayerMask.NameToLayer("Statue"))
            {
                enemy.GetComponent<StatueScript>().Rooted(rootDuration);
                enemy.GetComponent<StatueScript>().Marked(markDuration);
            }
            else if (enemy.gameObject.layer == LayerMask.NameToLayer("Minotaur"))
            {
                enemy.GetComponent<MinotaurScript>().Rooted(rootDuration);
                enemy.GetComponent<MinotaurScript>().Marked(markDuration);
            }
        }
        Destroy(gameObject);
    }
}
