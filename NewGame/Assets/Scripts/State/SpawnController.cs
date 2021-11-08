using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject greenSlime;
    private GameObject gSlime1;
    public GameObject Goblin1;
    private GameObject Goblin11;
    public GameObject Goblin2;
    public GameObject Worm;
    public GameObject Skeleton;
    public GameObject Orc1;
    public GameObject Orc2;
    public GameObject Statue;
    public GameObject Minotaur;
    // Start is called before the first frame update
    void Start()
    {
        //gSlime1 = Instantiate(greenSlime, new Vector2(10, 0), Quaternion.identity);
        //gSlime1.GetComponent<testSlime>().setStats(2);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            
            //GameObject gSlime = Instantiate(greenSlime, new Vector2(10, 0), Quaternion.identity);
            //gSlime.GetComponent<testSlime>().setStats(2);
            GameObject Goblin = Instantiate(Goblin1, new Vector2(10, 0), Quaternion.identity);
            Goblin.GetComponent<Goblin1Script>().setStats(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {

            GameObject gSlime = Instantiate(greenSlime, new Vector2(10, 0), Quaternion.identity);
            gSlime.GetComponent<testSlime>().setStats(2);
            
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {

            GameObject Goblinn = Instantiate(Goblin2, new Vector2(10, 0), Quaternion.identity);
            Goblinn.GetComponent<Goblin2Script>().setStats(2);

        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {

            GameObject WormEnemy = Instantiate(Worm, new Vector2(10, 0), Quaternion.identity);
            WormEnemy.GetComponent<WormScript>().setStats(2);

        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {

            GameObject SkeletonEnemy = Instantiate(Skeleton, new Vector2(10, 0), Quaternion.identity);
            SkeletonEnemy.GetComponent<SkeletonScript>().setStats(2);

        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {

            GameObject Orc1Enemy = Instantiate(Orc1, new Vector2(10, 0), Quaternion.identity);
            Orc1Enemy.GetComponent<Orc1Script>().setStats(2);

        }
        if (Input.GetKeyDown(KeyCode.P))
        {

            GameObject Orc2Enemy = Instantiate(Orc2, new Vector2(10, 0), Quaternion.identity);
            Orc2Enemy.GetComponent<Orc2Script>().setStats(2);

        }
        if (Input.GetKeyDown(KeyCode.O))
        {

            GameObject StatueEnemy = Instantiate(Statue, new Vector2(10, 0), Quaternion.identity);
            StatueEnemy.GetComponent<StatueScript>().setStats(2);
        }
        if (Input.GetKeyDown(KeyCode.I))
        {

            GameObject MinotaurEnemy = Instantiate(Minotaur, new Vector2(10, 0), Quaternion.identity);
            MinotaurEnemy.GetComponent<MinotaurScript>().setStats(2);
        }
    }
}
