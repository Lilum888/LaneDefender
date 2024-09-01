
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControler : MonoBehaviour
{
    private int spawnLocation;
    private int enemytype;
    [SerializeField] private GameObject spawn1;
    [SerializeField] private GameObject spawn2;
    [SerializeField] private GameObject spawn3;
    [SerializeField] private GameObject spawn4;
    [SerializeField] private GameObject spawn5;
    [SerializeField] private GameObject fastEnemy;
    [SerializeField] private GameObject mediumEnemy;
    [SerializeField] private GameObject slowEnemy;
    public bool playing = true;
    // Start is called before the first frame update
    void Start()
    {

        
        
            StartCoroutine(Spawn());
        
    }

    // Update is called once per frame
    void Update()
    {

    }


    private IEnumerator Spawn()
    {
        while (playing == true)
        {
            //choose random spawn point for random enemy 
            spawnLocation = Random.Range(1, 6);
            enemytype = Random.Range(1, 4);

            if (spawnLocation == 1)
            {
                if (enemytype == 1)
                {
                    GameObject newEnemy = Instantiate(fastEnemy, new Vector2(spawn1.transform.position.x, spawn1.transform.position.y), Quaternion.identity);
                    newEnemy.GetComponent<Rigidbody2D>().velocity = new Vector2(-5, 0);
                }
                if (enemytype == 2)
                {
                    GameObject newEnemy = Instantiate(mediumEnemy, new Vector2(spawn1.transform.position.x, spawn1.transform.position.y), Quaternion.identity);
                    newEnemy.GetComponent<Rigidbody2D>().velocity = new Vector2(-1, 0);
                }
                if (enemytype == 3)
                {
                    GameObject newEnemy = Instantiate(slowEnemy, new Vector2(spawn1.transform.position.x, spawn1.transform.position.y), Quaternion.identity);
                    newEnemy.GetComponent<Rigidbody2D>().velocity = new Vector2(-0.5f, 0);
                }

            }
            if (spawnLocation == 2)
            {
                if (enemytype == 1)
                {
                    GameObject newEnemy = Instantiate(fastEnemy, new Vector2(spawn2.transform.position.x, spawn2.transform.position.y), Quaternion.identity);
                    newEnemy.GetComponent<Rigidbody2D>().velocity = new Vector2(-5, 0);
                }
                if (enemytype == 2)
                {
                    GameObject newEnemy = Instantiate(mediumEnemy, new Vector2(spawn2.transform.position.x, spawn2.transform.position.y), Quaternion.identity);
                    newEnemy.GetComponent<Rigidbody2D>().velocity = new Vector2(-1, 0);
                }
                if (enemytype == 3)
                {
                    GameObject newEnemy = Instantiate(slowEnemy, new Vector2(spawn2.transform.position.x, spawn2.transform.position.y), Quaternion.identity);
                    newEnemy.GetComponent<Rigidbody2D>().velocity = new Vector2(-0.5f, 0);
                }
            }
            if (spawnLocation == 3)
            {
                if (enemytype == 1)
                {
                    GameObject newEnemy = Instantiate(fastEnemy, new Vector2(spawn3.transform.position.x, spawn3.transform.position.y), Quaternion.identity);
                    newEnemy.GetComponent<Rigidbody2D>().velocity = new Vector2(-5, 0);
                }
                if (enemytype == 2)
                {
                    GameObject newEnemy = Instantiate(mediumEnemy, new Vector2(spawn3.transform.position.x, spawn3.transform.position.y), Quaternion.identity);
                    newEnemy.GetComponent<Rigidbody2D>().velocity = new Vector2(-1, 0);
                }
                if (enemytype == 3)
                {
                    GameObject newEnemy = Instantiate(slowEnemy, new Vector2(spawn3.transform.position.x, spawn3.transform.position.y), Quaternion.identity);
                    newEnemy.GetComponent<Rigidbody2D>().velocity = new Vector2(-0.5f, 0);
                }
            }
            if (spawnLocation == 4)
            {
                if (enemytype == 1)
                {
                    GameObject newEnemy = Instantiate(fastEnemy, new Vector2(spawn4.transform.position.x, spawn4.transform.position.y), Quaternion.identity);
                    newEnemy.GetComponent<Rigidbody2D>().velocity = new Vector2(-5, 0);
                }
                if (enemytype == 2)
                {
                    GameObject newEnemy = Instantiate(mediumEnemy, new Vector2(spawn4.transform.position.x, spawn4.transform.position.y), Quaternion.identity);
                    newEnemy.GetComponent<Rigidbody2D>().velocity = new Vector2(-1, 0);
                }
                if (enemytype == 3)
                {
                    GameObject newEnemy = Instantiate(slowEnemy, new Vector2(spawn4.transform.position.x, spawn4.transform.position.y), Quaternion.identity);
                    newEnemy.GetComponent<Rigidbody2D>().velocity = new Vector2(-0.5f, 0);
                }
            }
            if (spawnLocation == 5)
            {
                if (enemytype == 1)
                {
                    GameObject newEnemy = Instantiate(fastEnemy, new Vector2(spawn5.transform.position.x, spawn5.transform.position.y), Quaternion.identity);
                    newEnemy.GetComponent<Rigidbody2D>().velocity = new Vector2(-5, 0);
                }
                if (enemytype == 2)
                {
                    GameObject newEnemy = Instantiate(mediumEnemy, new Vector2(spawn5.transform.position.x, spawn5.transform.position.y), Quaternion.identity);
                    newEnemy.GetComponent<Rigidbody2D>().velocity = new Vector2(-1, 0);
                }
                if (enemytype == 3)
                {
                    GameObject newEnemy = Instantiate(slowEnemy, new Vector2(spawn5.transform.position.x, spawn5.transform.position.y), Quaternion.identity);
                    newEnemy.GetComponent<Rigidbody2D>().velocity = new Vector2(-0.5f, 0);
                }
            }

            yield return new WaitForSeconds(2);
        }
    }
    public void StopSpawn()
    {
        playing = false;
    }
}
