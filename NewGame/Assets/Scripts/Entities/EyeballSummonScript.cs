using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeballSummonScript : MonoBehaviour
{
    public LayerMask enemyLayers;
    private bool isAttacking = false;
    private float aggroRange = 5.0f;
    public Transform attackPos;
    public int eyeballAttack;
    private float attackRange = 2.0f;
    private bool attackCD = false;
    private GameObject player;
    private SpriteRenderer eyeballRend;
    
    //
    
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        eyeballRend = GetComponent<SpriteRenderer>();
        if(player.GetComponent<PlayerController>().lastMovingDirection == 1)
        {
            Vector3 offset = new Vector3(1, 0, 0);
            transform.position += offset;
            eyeballRend.flipX = true;
        }
        else
        {
            Vector3 offset = new Vector3(-1, 0, 0);
            transform.position += offset;
            eyeballRend.flipX = false;
        }


    }

    // Update is called once per frame
    void Update()
    {
        if(player.GetComponent<PlayerController>().lastMovingDirection == 1)
        {
            //right
            if(eyeballRend.flipX == false)
            {
                Vector3 offset = new Vector3(2, 0, 0);
                transform.position += offset;
                //Debug.Log("right");
            }
            eyeballRend.flipX = true;
        }
        else
        {
            //left
            if (eyeballRend.flipX == true)
            {
                Vector3 offset = new Vector3(-2, 0, 0);
                transform.position += offset;
                //Debug.Log("left");
            }
            eyeballRend.flipX = false;

        }
        
        
        if (Physics2D.OverlapCircle(attackPos.position, attackRange, enemyLayers) != null && attackCD == false && player.GetComponent<PlayerController>().isStealth == false)
        {
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPos.position, attackRange, enemyLayers);
            foreach (Collider2D enemy in hitEnemies)
            {
                StartCoroutine(attack(enemy));
            }
        }
        
    }

    IEnumerator attack(Collider2D enemy)
    {
        attackCD = true;
        if (enemy.gameObject.layer == LayerMask.NameToLayer("Slime"))
        {
            enemy.GetComponent<testSlime>().Hit(eyeballAttack);
        }
        else if(enemy.gameObject.layer == LayerMask.NameToLayer("Goblin1"))
        {
            enemy.GetComponent<Goblin1Script>().Hit(eyeballAttack);
        }
        else if (enemy.gameObject.layer == LayerMask.NameToLayer("Goblin2"))
        {
            enemy.GetComponent<Goblin2Script>().Hit(eyeballAttack);
        }
        else if (enemy.gameObject.layer == LayerMask.NameToLayer("Worm"))
        {
            enemy.GetComponent<WormScript>().Hit(eyeballAttack);
        }
        else if (enemy.gameObject.layer == LayerMask.NameToLayer("Skeleton"))
        {
            enemy.GetComponent<SkeletonScript>().Hit(eyeballAttack);
        }
        else if (enemy.gameObject.layer == LayerMask.NameToLayer("Orc1"))
        {
            enemy.GetComponent<Orc1Script>().Hit(eyeballAttack);
        }
        else if (enemy.gameObject.layer == LayerMask.NameToLayer("Orc2"))
        {
            enemy.GetComponent<Orc2Script>().Hit(eyeballAttack);
        }
        else if (enemy.gameObject.layer == LayerMask.NameToLayer("Statue"))
        {
            enemy.GetComponent<StatueScript>().Hit(eyeballAttack);
        }
        else if (enemy.gameObject.layer == LayerMask.NameToLayer("Minotaur"))
        {
            enemy.GetComponent<MinotaurScript>().Hit(eyeballAttack);
        }
        yield return new WaitForSeconds(1.5f);
        attackCD = false;
    }
}
