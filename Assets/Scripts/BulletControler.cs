using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControler : MonoBehaviour
{

    [SerializeField] private GameObject Bullet;
    [SerializeField] private GameObject Explosion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject newExplosion = Instantiate(Explosion, new Vector2(Bullet.transform.position.x, Bullet.transform.position.y),Quaternion.identity);
        Destroy(newExplosion, 0.1f);
        Destroy(gameObject);

    }
}

