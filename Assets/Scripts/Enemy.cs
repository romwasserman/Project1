using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject zombie;
    public GameObject ghost;
    public GameObject Player;
    private Vector3 playerPos;
    public float speed;
    private float Timer;
    private int numEnemies;
    private GameObject Clone;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = new Vector3(Player.transform.position.x, transform.position.y, Player.transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, playerPos, speed * Time.deltaTime);
        float random = Random.Range(0, 1);
        if (random == 0)
        {
            print(random);
            Timer += Time.deltaTime;
            if (Timer >= 3f)
            {
                Instantiate(ghost, (new Vector3((Random.Range(-10f, 10f)), 5, 0)), transform.rotation);
                numEnemies++;
                print(numEnemies);
            }
            Timer = 0;
        }
        else
        {
            print(random);
            Timer += Time.deltaTime;
            if (Timer >= 3f)
            {
                Instantiate(zombie, (new Vector3((Random.Range(-10f, 10f)), 5, 0)), transform.rotation);
                numEnemies++;
                print(numEnemies);

            }
            Timer = 0;
        }
    }
}
