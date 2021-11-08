using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    private Animator animator;
    public LayerMask enemyLayers;
    public bool stealth;
    public int stunChance;
    public int stunDuration;
    // Start is called before the first frame update//
    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(Explosion());
    }


    IEnumerator Explosion()
    {
        yield return new WaitForSeconds(2.0f);
        if (stealth == true)
        {
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, 1.3f, enemyLayers);
            foreach (Collider2D enemy in hitEnemies)
            {
                if (enemy.gameObject.layer == LayerMask.NameToLayer("Slime"))
                {
                    enemy.GetComponent<testSlime>().Hit(30);
                    enemy.GetComponent<testSlime>().Stunned(stunChance, stunDuration);
                }
                else if(enemy.gameObject.layer == LayerMask.NameToLayer("Goblin1"))
                {
                    enemy.GetComponent<Goblin1Script>().Hit(30);
                    enemy.GetComponent<Goblin1Script>().Stunned(stunChance, stunDuration);
                }
                else if (enemy.gameObject.layer == LayerMask.NameToLayer("Goblin2"))
                {
                    enemy.GetComponent<Goblin2Script>().Hit(30);
                    enemy.GetComponent<Goblin2Script>().Stunned(stunChance, stunDuration);
                }
                else if (enemy.gameObject.layer == LayerMask.NameToLayer("Worm"))
                {
                    enemy.GetComponent<WormScript>().Hit(30);
                    enemy.GetComponent<WormScript>().Stunned(stunChance, stunDuration);
                }
                else if (enemy.gameObject.layer == LayerMask.NameToLayer("Skeleton"))
                {
                    enemy.GetComponent<SkeletonScript>().Hit(30);
                    enemy.GetComponent<SkeletonScript>().Stunned(stunChance, stunDuration);
                }
                else if (enemy.gameObject.layer == LayerMask.NameToLayer("Orc1"))
                {
                    enemy.GetComponent<Orc1Script>().Hit(30);
                    enemy.GetComponent<Orc1Script>().Stunned(stunChance, stunDuration);
                }
                else if (enemy.gameObject.layer == LayerMask.NameToLayer("Orc2"))
                {
                    enemy.GetComponent<Orc2Script>().Hit(30);
                    enemy.GetComponent<Orc2Script>().Stunned(stunChance, stunDuration);
                }
                else if (enemy.gameObject.layer == LayerMask.NameToLayer("Statue"))
                {
                    enemy.GetComponent<StatueScript>().Hit(30);
                    enemy.GetComponent<StatueScript>().Stunned(stunChance, stunDuration);
                }
                else if (enemy.gameObject.layer == LayerMask.NameToLayer("Minotaur"))
                {
                    enemy.GetComponent<MinotaurScript>().Hit(30);
                    enemy.GetComponent<MinotaurScript>().Stunned(stunChance, stunDuration);
                }
            }
        }
        else
        {
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, 1.3f, enemyLayers);
            foreach (Collider2D enemy in hitEnemies)
            {
                if (enemy.gameObject.layer == LayerMask.NameToLayer("Slime"))
                {
                    enemy.GetComponent<testSlime>().Hit(30);
                }
                else if (enemy.gameObject.layer == LayerMask.NameToLayer("Goblin1"))
                {
                    enemy.GetComponent<Goblin1Script>().Hit(30);
                }
                else if (enemy.gameObject.layer == LayerMask.NameToLayer("Goblin2"))
                {
                    enemy.GetComponent<Goblin2Script>().Hit(30);
                }
                else if (enemy.gameObject.layer == LayerMask.NameToLayer("Worm"))
                {
                    enemy.GetComponent<WormScript>().Hit(30);
                }
                else if (enemy.gameObject.layer == LayerMask.NameToLayer("Skeleton"))
                {
                    enemy.GetComponent<SkeletonScript>().Hit(30);
                }
                else if (enemy.gameObject.layer == LayerMask.NameToLayer("Orc1"))
                {
                    enemy.GetComponent<Orc1Script>().Hit(30);
                }
                else if (enemy.gameObject.layer == LayerMask.NameToLayer("Orc2"))
                {
                    enemy.GetComponent<Orc2Script>().Hit(30);
                }
                else if (enemy.gameObject.layer == LayerMask.NameToLayer("Statue"))
                {
                    enemy.GetComponent<StatueScript>().Hit(30);
                }
                else if (enemy.gameObject.layer == LayerMask.NameToLayer("Minotaur"))
                {
                    enemy.GetComponent<MinotaurScript>().Hit(30);
                }
            }
        }
        animator.SetTrigger("Explosion");
    }
    
}
